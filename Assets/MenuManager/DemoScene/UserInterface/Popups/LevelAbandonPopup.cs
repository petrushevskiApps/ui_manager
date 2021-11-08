using System.Collections;
using System.Collections.Generic;
using System.Threading;
using PetrushevskiApps.UIManager;
using UnityEngine;

namespace slowBulletGames.MemoryValley
{
    public class LevelAbandonPopup : UIPopup
    {
        [Header("Buttons")]

        [SerializeField] private UIButton yesButton;
        [SerializeField] private UIButton noButton;

        private void Awake()
        {
            yesButton.onClick.AddListener(OnYesClicked);
            noButton.onClick.AddListener(OnNoClicked);
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


        private void OnNoClicked()
        {
            Close();
        }

        private void OnYesClicked()
        {
            Close();
        }
    }


}