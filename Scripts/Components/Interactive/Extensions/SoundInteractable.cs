using TwoOneTwoGames.UIManager.Data;
using TwoOneTwoGames.UIManager.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace TwoOneTwoGames.UIManager.Components.Interactive
{
    /// <summary>
    ///     This component extends the Selectable Unity Component
    ///     with Sound Effects functionality depending on the
    ///     interactive state of the Selectable.
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

        private IUiAudioPalette _uiAudioPalette;

        // Injected
        private IUiSoundSystem _uiSoundSystem;

        public void OnPointerDown(PointerEventData eventData)
        {
            _uiSoundSystem?.PlayUiSoundEffect(Selectable.interactable
                ? GetPositiveSound()
                : GetNegativeSound());
        }

        [Inject]
        public void Initialize(
            IUiSoundSystem uiSoundSystem,
            IUiAudioPalette uiAudioPalette)
        {
            _uiSoundSystem = uiSoundSystem;
            _uiAudioPalette = uiAudioPalette;
        }

        private AudioClip GetPositiveSound()
        {
            return _positiveSound != null ? _positiveSound : _uiAudioPalette.ActiveInteractableElementClicked;
        }

        private AudioClip GetNegativeSound()
        {
            return _negativeSound != null ? _negativeSound : _uiAudioPalette.InactiveInteractableElementClicked;
        }
    }
}