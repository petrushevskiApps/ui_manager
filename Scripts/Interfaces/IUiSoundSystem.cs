using UnityEngine;

namespace TwoOneTwoGames.UIManager.Interfaces
{
    public interface IUiSoundSystem
    {
        void PlayUiSoundEffect(AudioClip clip, bool isLooping = false, float pitch = 1);
        void PlayBackgroundMusic(AudioClip audio, bool isLoop = true, bool isInMenu = true);
        void StopBackgroundMusic(bool isInMenu = true);
        void StopUiSoundEffects();
    }
}