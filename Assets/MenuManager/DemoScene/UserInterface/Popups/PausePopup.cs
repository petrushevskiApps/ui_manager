using PetrushevskiApps.UIManager;
using UnityEngine;

namespace slowBulletGames.MemoryValley
{
    public class PausePopup : UIPopup
    {
        [Header("Buttons")]
        [SerializeField] private UIButton replayButton;
        [SerializeField] private UIButton homeButton;
        [SerializeField] private UIButton playButton;
        [SerializeField] private UIButton settingsButton;

        private void Awake()
        {
            replayButton.onClick.AddListener(OnReplayClicked);
            homeButton.onClick.AddListener(OnHomeClicked);
            playButton.onClick.AddListener(OnPlayClicked);
            settingsButton.onClick.AddListener(OnSettingsClicked);
        }
        public override void Open()
        {
            base.Open();
            Time.timeScale = 0;
        }

        public override void Close()
        {
            base.Close();
            Time.timeScale = 1;
        }
        private void OnReplayClicked()
        {
            Close();
        }
        private void OnHomeClicked()
        {
            UIManager.Instance.OpenPopup<LevelAbandonPopup>();
        }
        protected virtual void OnPlayClicked()
        {
            OnBackButtonPressed();
        }
        private void OnSettingsClicked()
        {
            UIManager.Instance.OpenPopup<SettingsPopup>();
        }
    }


}