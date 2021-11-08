using System;
using System.Collections;
using System.Collections.Generic;
using PetrushevskiApps.UIManager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace slowBulletGames.MemoryValley
{
    public class LevelCompletedPopup : UIPopup
    {
        [SerializeField] private GameObject keysInfo;
        [SerializeField] private GameObject popupLayout;
        [SerializeField] private TextMeshProUGUI message;

        [Header("Buttons")]
        [SerializeField] private UIButton replayButton;
        [SerializeField] private UIButton homeButton;
        [SerializeField] private UIButton playButton;

        private void Awake()
        {
            replayButton.onClick.AddListener(OnReplayClicked);
            homeButton.onClick.AddListener(OnHomeClicked);
            playButton.onClick.AddListener(OnPlayClicked);
        }

        public override void Initialize(Action onBackButtonAction)
        {
            //GameManager.LevelStartEvent.AddListener(OnLevelStart);
            base.Initialize(onBackButtonAction);
        }

        private void OnDestroy()
        {
            //GameManager.LevelStartEvent.RemoveListener(OnLevelStart);
        }
        private void OnLevelStart(int arg0)
        {
            SetKeysInfo();
            SetMessage();
        }

        private void SetKeysInfo()
        {
            //bool isKeysInfoActive = GameManager.Instance.ActiveLevel.GetKeysInLevel() > 0;
            //keysInfo?.SetActive(isKeysInfoActive);

        }


        private void SetMessage()
        {
            //string levelName = GameManager.Instance.ActiveLevel.Title;
            //message.text = $"Awesome! \n Level {levelName} Completed!";
        }


        private void OnPlayClicked()
        {
            Close();
            //GameManager.Instance.StartNextLevel();
        }

        private void OnReplayClicked()
        {
            Close();
            //GameManager.Instance.StartLevel();
        }

        private void OnHomeClicked()
        {
            Close();
            //GameManager.Instance.ExitLevel();
        }

        public override void OnBackButtonPressed()
        {
            OnHomeClicked();
        }
    }

}