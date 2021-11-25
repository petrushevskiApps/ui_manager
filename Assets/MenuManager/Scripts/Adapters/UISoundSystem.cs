using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UISoundSystem : MonoBehaviour, ISoundSystem
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
