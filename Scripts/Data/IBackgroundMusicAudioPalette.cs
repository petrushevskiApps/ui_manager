using UnityEngine;

public interface IBackgroundMusicAudioPalette
{
    AudioClip MainScreenBackgroundMusic { get; }
    AudioClip InGameBackgroundMusic { get; }
}