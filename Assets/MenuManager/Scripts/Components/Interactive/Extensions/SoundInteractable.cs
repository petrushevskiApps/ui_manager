using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace PetrushevskiApps.UIManager
{
    /// <summary>
    /// This component extends the Selectable Unity Component
    /// with Sound Effects functionality depending on the
    /// interactive state of the Selectable.
    /// </summary>
    public class SoundInteractable : SelectableExtension, IPointerDownHandler
    {
        [Header("Override Defaults")]
        [SerializeField]
        [Tooltip("Override for the default interaction sound. Played when the selectable is interactive.")]
        private AudioClip _positiveSound;
        [SerializeField]
        [Tooltip("Override for the default interaction sound. Played when the selectable is not interactive.")]
        private AudioClip _negativeSound;

        // Injected
        private ISoundSystem _soundSystem;
        private IInteractableSoundConfig _interactableSoundConfig;

        [Inject]
        public void Initialize(
            ISoundSystem soundSystem,
            IInteractableSoundConfig interactableSoundConfig)
        {
            _soundSystem = soundSystem;
            _interactableSoundConfig = interactableSoundConfig;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _soundSystem?.PlaySoundEffect(Selectable.interactable
                ? GetPositiveSound()
                : GetNegativeSound());
        }

        private AudioClip GetPositiveSound()
        {
            return _positiveSound != null ? _positiveSound : _interactableSoundConfig.PositiveSound;
        }
        
        private AudioClip GetNegativeSound()
        {
            return _negativeSound != null ? _negativeSound : _interactableSoundConfig.NegativeSound;
        }
    }
}