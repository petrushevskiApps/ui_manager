using System.Collections;
using System.Collections.Generic;
using PetrushevskiApps.UIManager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace slowBulletGames.MemoryValley
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI levelName;
        [SerializeField] private CanvasGroup keysGroup;
        [SerializeField] private TextMeshProUGUI keysStatus;
        [SerializeField] private GameObject lockIcon;

        [SerializeField] private Color unlockedTextColor;
        [SerializeField] private Color completedTextColor;

        private UIButton levelButton;

        private void Awake()
        {
            levelButton = GetComponent<UIButton>();
            levelButton.onClick.AddListener(OnLevelClicked);
        }

        //public void Initialize(LevelData levelData)
        //{
        //    //data = levelData;
        //    //name = $"Level_{levelData.Title}";

        //    SetLevelName();
        //    ToggleLock();
        //    SetButton();
        //    SetKeysStatus();
        //}

        private void SetKeysStatus()
        {
            //int keysInLevel = data.GetKeysInLevel();
            //if (keysInLevel > 0)
            //{
            //    int keysCollected = data.CollectedKeysCount;
            //    keysStatus.SetText($"{keysCollected}/{keysInLevel}");
            //    keysGroup.gameObject.SetActive(true);
            //}
            //else
            //{
            //    keysGroup.gameObject.SetActive(false);
            //}
        }

        private void SetButton()
        {
            //levelButton.SetInteractableStatus(data.IsUnlocked);
        }

        private void SetLevelName()
        {
            //string newName = data.Id + 1 < 10 ? $"0{data.Title}" : data.Title;
            //levelName.SetText(newName);
            //levelName.gameObject.SetActive(data.IsUnlocked);


            //if (data.IsCompleted)
            //{
            //    levelName.color = completedTextColor;
            //}
            //else
            //{
            //    levelName.color = unlockedTextColor;
            //}
        }
        private void ToggleLock()
        {
            //lockIcon.SetActive(!data.IsUnlocked);
        }


        private void OnLevelClicked()
        {
            //GameManager.Instance.StartSelectedLevel(data.Id);
        }
    }

}