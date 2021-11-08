using System.Collections;
using System.Collections.Generic;
using PetrushevskiApps.UIManager;
using UnityEngine;

namespace slowBulletGames.MemoryValley
{
    public class WorldCompletedPopup : UIPopup
    {
        [Header("Buttons")]
        [SerializeField] private UIButton replayButton;
        [SerializeField] private UIButton homeButton;

        private void Awake()
        {
            replayButton.onClick.AddListener(OnReplayClicked);
            homeButton.onClick.AddListener(OnHomeClicked);
        }

        private void OnReplayClicked()
        {
            Close();
        }

        private void OnHomeClicked()
        {
            Close();
        }

        public override void OnBackButtonPressed()
        {
            OnHomeClicked();
        }
    }
}
