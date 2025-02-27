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
        
        [Header("Popup Properties")]
        [SerializeField]
        private TextMeshProUGUI _title;
        [SerializeField]
        private TextMeshProUGUI _message;
        
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
            gameObject.SetActive(true);
            PlaySfx(_popupSoundConfiguration.PopupShown);
            SetTitleAndMessage();
            if (_pauseGameWhenActive)
            {
                Time.timeScale = 0;
            }
        }

        public virtual void Hide()
        {
            PopupScreenHiddenEvent?.Invoke(this, EventArgs.Empty);
            gameObject.SetActive(false);
            
            if (_pauseGameWhenActive)
            {
                Time.timeScale = 1;
            }
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

        private void SetTitleAndMessage()
        {
            IPopupViewModel viewModel = GetPopupViewModel();
            if (viewModel != null)
            {
                _title.text = viewModel.Title;
                _message.text = viewModel.Message;
                ToggleTitleAndMessage(true);
            }
            else
            {
                ToggleTitleAndMessage(false);
            }
            
        }

        private void ToggleTitleAndMessage(bool isActive)
        {
            _title.gameObject.SetActive(isActive);
            _message.gameObject.SetActive(isActive);
        }
    }
}