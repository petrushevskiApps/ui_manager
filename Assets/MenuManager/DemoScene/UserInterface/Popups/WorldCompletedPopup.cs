using PetrushevskiApps.UIManager;
using UnityEngine;

namespace slowBulletGames.MemoryValley
{
    public class WorldCompletedPopup : UIPopup
    {
        [Header("Buttons")]
        [SerializeField]
        private UIButton _replayButton;

        [SerializeField]
        private UIButton _homeButton;

        private void Awake()
        {
            _replayButton.onClick.AddListener(OnReplayClicked);
            _homeButton.onClick.AddListener(OnHomeClicked);
        }

        private void OnReplayClicked()
        {
            Close();
        }

        private void OnHomeClicked()
        {
            Close();
        }

        public void OnBackButtonPressed()
        {
            OnHomeClicked();
        }
    }
}