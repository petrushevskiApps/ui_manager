using UnityEngine;

public interface IBackgroundMusicAudioPalette
{
    AudioClip MainScreenBackgroundMusic { get; }
    AudioClip InGameBackgroundMusic { get; }
    AudioClip LevelCompletedBackgroundMusic { get; }
    AudioClip LevelFailedBackgroundMusic { get; }
}