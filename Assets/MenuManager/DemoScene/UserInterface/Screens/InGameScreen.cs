using System.Collections;
using System.Collections.Generic;
using PetrushevskiApps.UIManager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace slowBulletGames.MemoryValley
{
    public class InGameScreen : UIScreen
    {
        [SerializeField] private TextMeshProUGUI levelTitle;
        [SerializeField] private Image progressFill;

        [Header("Buttons")]
        [SerializeField] private UIButton pauseButton;
        [SerializeField] private UIButton hintButton;

        private new void Awake()
        {
            base.Awake();

            //GameManager.LevelStartEvent.AddListener(OnLevelStarted);
            //LevelManager.OnLevelProgress.AddListener(OnLevelProgress);
            pauseButton.onClick.AddListener(OnPauseClicked);
            hintButton.onClick.AddListener(OnHintClicked);

            SetLevelTitle();
            SetProgress(0);
        }

        private void OnLevelProgress(float progress)
        {
            SetProgress(1 - progress);
        }

        private void OnLevelStarted(int levelId)
        {
            //SetLevelTitle(GameManager.Instance.ActiveLevel.Title);
            SetProgress(0);
        }

        private void SetLevelTitle(string title = "")
        {
            levelTitle.text = $"Level {title}";
        }

        private void SetProgress(float progress)
        {
            progressFill.fillAmount = progress;
        }

        private void OnHintClicked()
        {
            throw new System.NotImplementedException();
        }

        private void OnPauseClicked()
        {
            UIManager.Instance.OpenPopup<PausePopup>();
        }

        public override void OnBackButtonPressed()
        {
            UIManager.Instance.OpenPopup<LevelAbandonPopup>();
        }
    }

}