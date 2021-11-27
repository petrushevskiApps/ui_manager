using UnityEngine;
using UnityEngine.EventSystems;

namespace PetrushevskiApps.UIManager
{
    [RequireComponent(typeof(InteractivityMonitor))]
    public class SoundInteractable : SelectableExtension, IPointerDownHandler
    {
        [SerializeField] protected InteractableSoundConfig soundConfig;

        private ISoundSystem iSoundSystem;
        private AudioClip soundEffect;
        private InteractivityMonitor interactivityMonitor;

        private void Start()
        {
            iSoundSystem = UIManager.Instance.GetComponent<ISoundSystem>();
            interactivityMonitor = GetComponent<InteractivityMonitor>();

            interactivityMonitor?.InteractivityChangedEvent.AddListener(SetAudioClip);
        }

        private void OnDestroy()
        {
            interactivityMonitor?.InteractivityChangedEvent.AddListener(SetAudioClip);
        }

        private void SetAudioClip(bool isInteractable)
        {
            if (isInteractable)
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