using PetrushevskiApps.UIManager;
using UnityEngine;

namespace slowBulletGames.MemoryValley
{
    public class PausePopup : UIPopup
    {
        [Header("Buttons")]
        [SerializeField]
        private UIButton _replayButton;

        [SerializeField]
        private UIButton _homeButton;

        [SerializeField]
        private UIButton _playButton;

        [SerializeField]
        private UIButton _settingsButton;

        private void Awake()
        {
            _replayButton.onClick.AddListener(OnReplayClicked);
            _homeButton.onClick.AddListener(OnHomeClicked);
            _playButton.onClick.AddListener(OnPlayClicked);
            _settingsButton.onClick.AddListener(OnSettingsClicked);
        }

        public override void Resume()
        {
            base.Resume();
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
            NavigationController.ShowPopup<LevelAbandonPopup>();
        }

        protected virtual void OnPlayClicked()
        {
            NavigationController.GoBack();
        }

        private void OnSettingsClicked()
        {
            NavigationController.ShowPopup<SettingsPopup>();
        }
    }
}