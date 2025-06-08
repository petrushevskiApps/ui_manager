using UnityEngine;

namespace TwoOneTwoGames.UIManager.Data
{
    public interface IBackgroundMusicAudioPalette
    {
        AudioClip MainScreenBackgroundMusic { get; }
        AudioClip InGameBackgroundMusic { get; }
    }
}