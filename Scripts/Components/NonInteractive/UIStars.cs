using System;
using System.Collections;
using System.Collections.Generic;
using Plugins.UIManager.Scripts.Data;
using UnityEngine;
using Zenject;

public class UIStars : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _stars;

    private IUiSoundSystem _uiSoundSystem;
    private IUiAudioPalette _uiAudioPalette;

    [Inject]
    public void Setup(
        IUiSoundSystem uiSoundSystem,
        IUiAudioPalette uiAudioPalette)
    {
        _uiSoundSystem = uiSoundSystem;
        _uiAudioPalette = uiAudioPalette;
    }
    
    private void Awake()
    {
        ClearStars();
    }

    private void OnDisable()
    {
        ClearStars();
    }

    public void SetData(int starsCount)
    {
        gameObject.SetActive(true);
        for (int i = 0; i < starsCount; i++)
        {
            var index = i;
            StartCoroutine(DelayInvoke( () =>
            {
                _stars[index].SetActive(true);
                _uiSoundSystem?.PlayUiSoundEffect(_uiAudioPalette.StarShown);
            }, 0.4f * index));
        }

    }

    private IEnumerator DelayInvoke(Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action?.Invoke();
    }
    private void ClearStars()
    {
        _stars.ForEach(star => star.SetActive(false));
    }
}
