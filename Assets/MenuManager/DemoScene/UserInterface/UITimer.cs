using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace slowBulletGames.MemoryValley
{
    public class UITimer : MonoBehaviour
    {
        [SerializeField] private Image timerProgress;

        private float fullTime;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void InitializeTimer()
        {
            //Register events
        }

        private void OnDestroy()
        {
            //Un-Register events
        }

        private void OnTimerStart(float timerLength)
        {
            gameObject.SetActive(true);
            fullTime = timerLength;
            SetTimerProgress(fullTime);
        }


        private void OnTimerTick(float currentTime)
        {
            SetTimerProgress(currentTime / fullTime);
        }


        private void SetTimerProgress(float fill)
        {
            timerProgress.fillAmount = fill;

            if (timerProgress.fillAmount <= 0.001f)
            {
                gameObject.SetActive(false);
            }
        }
    }

}