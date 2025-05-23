using UnityEngine;

public interface IUiSoundSystem
{
    void PlaySoundEffect(AudioClip clip);
    void PlayBackgroundMusic(AudioClip levelFailedBackgroundMusic);
    void StopBackgroundMusic();
}
