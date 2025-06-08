using System;
using System.Collections;
using System.Collections.Generic;
using TwoOneTwoGames.UIManager.Data;
using TwoOneTwoGames.UIManager.Interfaces;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Components.NonInteractive
{
    public class UIStars : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _stars;

        private IUiAudioPalette _uiAudioPalette;

        private IUiSoundSystem _uiSoundSystem;

        private void Awake()
        {
            ClearStars();
        }

        private void OnDisable()
        {
            ClearStars();
        }

        [Inject]
        public void Setup(
            IUiSoundSystem uiSoundSystem,
            IUiAudioPalette uiAudioPalette)
        {
            _uiSoundSystem = uiSoundSystem;
            _uiAudioPalette = uiAudioPalette;
        }

        public void SetData(int starsCount)
        {
            gameObject.SetActive(true);
            for (var i = 0; i < starsCount; i++)
            {
                var index = i;
                StartCoroutine(DelayInvoke(() =>
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
}