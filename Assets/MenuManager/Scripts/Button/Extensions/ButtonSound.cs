using UnityEngine;
using UnityEngine.EventSystems;

namespace PetrushevskiApps.UIManager
{
    public class ButtonSound : ButtonExtension, IPointerDownHandler
    {
        [SerializeField] protected ButtonSoundConfig soundConfig;

        private ISoundSystem iSoundSystem;
        private UIButton button;
        private AudioClip soundEffect;

        private void Start()
        {
            button = GetComponent<UIButton>();
            iSoundSystem = UIManager.Instance.GetComponent<ISoundSystem>();

            button?.InteractableChangedEvent.AddListener(SetAudioClip);
        }

        private void OnDestroy()
        {
            button?.InteractableChangedEvent.RemoveListener(SetAudioClip);
        }

        private void SetAudioClip()
        {
            if (button.IsInteractable)
            {
                soundEffect = soundConfig.positiveSound;
            }
            else
            {
                soundEffect = soundConfig.negativeSound;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            iSoundSystem?.PlaySoundEffect(soundEffect);
        }
    }
}