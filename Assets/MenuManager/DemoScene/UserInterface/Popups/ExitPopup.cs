using System.Collections;
using System.Collections.Generic;
using PetrushevskiApps.UIManager;
using UnityEngine;

namespace slowBulletGames.MemoryValley
{
    public class ExitPopup : UIPopup
    {
        [SerializeField] private UIButton yesButton;
        [SerializeField] private UIButton noButton;

        private void Awake()
        {
            yesButton.onClick.AddListener(OnYesClicked);
            noButton.onClick.AddListener(OnNoClicked);
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
