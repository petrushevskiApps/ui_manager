using UnityEngine;

namespace Plugins.UIManager.Scripts.Data
{
    public interface IUiAudioPalette
    {
        AudioClip ActiveInteractableElementClicked { get; }
        AudioClip InactiveInteractableElementClicked { get; }
        AudioClip PopupShown { get; }
        AudioClip PopupHidden { get; }
        AudioClip StarShown { get; }
        AudioClip LevelCompletedBackgroundMusic { get; }
        AudioClip LevelFailedBackgroundMusic { get; }
    }
}