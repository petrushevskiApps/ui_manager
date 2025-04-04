using System;
using slowBulletGames.MemoryValley;
using TMPro;
using UnityEngine;
using Zenject;

namespace PetrushevskiApps.UIManager
{
    public abstract class UIPopup : MonoBehaviour, IScreen, IPopupScreenEvents
    {
        [SerializeField]
        [Tooltip("True: Popup goes on backstack when hidden. False: One time popup.")]
        private bool _isBackStackable = true;

        [SerializeField]
        [Tooltip("True: When this popup is shown the Game Time is set to 0. False: Ignores this setting.")]
        private bool _pauseGameWhenActive = false;

        [SerializeField]
        [Tooltip("Clickable background which disposes the popup when clicked.Same as the Back Button.")]
        private UIButton _popupClickableBackground;
        
        [Header("Popup Properties")]
        [SerializeField]
        private TextMeshProUGUI _title;
        [SerializeField]
        private TextMeshProUGUI _message;
        
        public bool IsPopup => true;
        public bool IsBackStackable => _isBackStackable;
        
        // Events
        public event EventHandler PopupScreenShownEvent;
        public event EventHandler PopupScreenResumedEvent;
        public event EventHandler PopupScreenHiddenEvent;
        public event EventHandler PopupScreenClosedEvent;
        
        // Injected
        private ISoundSystem _soundSystem;
        private IPopupSoundConfiguration _popupSoundConfiguration;
        protected INavigationController NavigationController;
        
        protected abstract IPopupViewModel GetPopupViewModel();
        
        [Inject]
        public void Initialize(
            ISoundSystem soundSystem,
            IPopupSoundConfiguration popupSoundConfiguration,
            INavigationController navigationController)
        {
            _soundSystem = soundSystem;
            _popupSoundConfiguration = popupSoundConfiguration;
            NavigationController = navigationController;
        }
        
        public void Show<TArguments>(TArguments navArguments)
        {
            PopupScreenShownEvent?.Invoke(this, EventArgs.Empty);
            Resume();
        }

        public virtual void Resume()
        {
            PopupScreenResumedEvent?.Invoke(this, EventArgs.Empty);
            _popupClickableBackground.OnClick.AddListener(GetPopupViewModel().BackgroundClicked);
            if (_title != null)
            {
                GetPopupViewModel().Title?.Subscribe(SetTitle, triggerOnSubscribe: true);
            }
            if (_message != null)
            {
                GetPopupViewModel().Message?.Subscribe(SetMessage, triggerOnSubscribe: true);
            }
            gameObject.SetActive(true);
            PlaySfx(_popupSoundConfiguration.PopupShown);
            PauseGame(true);
        }
        
        public virtual void Hide()
        {
            PopupScreenHiddenEvent?.Invoke(this, EventArgs.Empty);
            _popupClickableBackground.OnClick.RemoveListener(GetPopupViewModel().BackgroundClicked);
            gameObject.SetActive(false);
            if (_title != null)
            {
                GetPopupViewModel().Title?.Unsubscribe(SetTitle);
            }
            if (_message != null)
            {
                GetPopupViewModel().Message?.Unsubscribe(SetMessage);
            }
            PauseGame(false);
        }

        public virtual void Close()
        {
            PopupScreenClosedEvent?.Invoke(this, EventArgs.Empty);
            PlaySfx(_popupSoundConfiguration.PopupHidden);
            Hide();
        }

        private void PlaySfx(AudioClip sfxClip)
        {
            if (sfxClip != null)
            {
                _soundSystem?.PlaySoundEffect(sfxClip);
            }
        }
        
        private void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                _title.gameObject.SetActive(false);
                return;
            }
            _title.gameObject.SetActive(true);
            _title.text = title;
        }
        private void SetMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                _message.gameObject.SetActive(false);
                return;
            }
            _message.gameObject.SetActive(true);
            _message.text = message;
        }

        private void PauseGame(bool pause)
        {
            if (_pauseGameWhenActive)
            {
                Time.timeScale = pause ? 0 : 1;
            }
        }

        public void OnBackTriggered()
        {
            NavigationController.GoBack();
        }
    }
}