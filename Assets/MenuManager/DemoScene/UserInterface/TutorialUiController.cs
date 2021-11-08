using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace slowBulletGames.MemoryValley
{
    public class TutorialUiController : MonoBehaviour
    {
        [SerializeField] private Image tutorialIcon;
        [SerializeField] private TextMeshProUGUI tutorialText;

        private bool isTutorial;

        private void ToggleTutorial(bool isShown)
        {
            gameObject.SetActive(isShown);
        }

        private void SetText(string text)
        {
            tutorialText.text = text;
        }

        private void SetIcon(Sprite icon)
        {
            tutorialIcon.sprite = icon;
        }
    }

}