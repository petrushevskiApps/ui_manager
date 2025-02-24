using UnityEngine;

public interface IPopupSoundConfiguration
{
    AudioClip PopupShown { get; }
    AudioClip PopupHidden { get; }
}