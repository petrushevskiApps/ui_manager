using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PetrushevskiApps.UIManager
{
    public abstract class UIPopup : UIWindow
    {
        [HideInInspector] public UnityEvent OnPopupShown = new UnityEvent();
        [HideInInspector] public UnityEvent OnPopupHiden = new UnityEvent();
        [HideInInspector] public UnityEvent OnPopupOpen = new UnityEvent();
        [HideInInspector] public UnityEvent OnPopupClosed = new UnityEvent();

        [SerializeField] private PopupSoundConfiguration soundConfiguration;

        public override void Show()
        {
            gameObject.SetActive(true);
            OnPopupShown.Invoke();
        }
        
        public override void Hide()
        {
            gameObject.SetActive(false);
            OnPopupHiden.Invoke();
        }

        public override void Open()
        {
            gameObject.SetActive(true);
            PlaySfx(soundConfiguration?.PopupShown);
            OnPopupOpen.Invoke();
        }
        public override void Close()
        {
            gameObject.SetActive(false);
            PlaySfx(soundConfiguration?.PopupHidden);
            UIManager.Instance.ClosePopup(this);
            OnPopupClosed.Invoke();
        }

        private void PlaySfx(AudioClip sfxClip)
        {
            if (sfxClip != null)
            {
                UIManager.Instance.SoundSystem?.PlaySoundEffect(sfxClip);
            }
        }
    }
}


