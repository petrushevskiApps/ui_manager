using System;
using UnityEngine;
using Zenject;

namespace PetrushevskiApps.UIManager
{
    public abstract class UIPopup : MonoBehaviour, IScreen, IPopupScreenEvents
    {
        [SerializeField]
        [Tooltip("True: Popup goes on backstack when hidden. False: One time popup.")]
        private bool _isBackStackable = true;

        public bool IsBackStackable => _isBackStackable;
        
        // Events
        public event EventHandler PopupScreenShownEvent;
        public event EventHandler PopupScreenResumedEvent;
        public event EventHandler PopupScreenHiddenEvent;
        public event EventHandler PopupScreenClosedEvent;
        
        // Injected
        private ISoundSystem _soundSystem;
        private IPopupSoundConfiguration _popupSoundConfiguration;
        
        [Inject]
        public void Initialize(
            ISoundSystem soundSystem,
            IPopupSoundConfiguration popupSoundConfiguration)
        {
            _soundSystem = soundSystem;
            _popupSoundConfiguration = popupSoundConfiguration;
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
        }

        public virtual void Hide()
        {
            PopupScreenHiddenEvent?.Invoke(this, EventArgs.Empty);
            gameObject.SetActive(false);
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

    }
}