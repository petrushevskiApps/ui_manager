using System;
using System.Collections;
using System.Collections.Generic;
using PetrushevskiApps.UIManager;
using UnityEngine;

namespace slowBulletGames.MemoryValley
{
    public class LevelsScreen : UIScreen
    {
        [Header("Buttons")]
        [SerializeField] private UIButton leftArrowButton;
        [SerializeField] private UIButton rightArrowButton;

        [Header("LevelsFunnel Grid")]
        [SerializeField] private Transform levelsParent;
        [SerializeField] private GameObject levelPrefab;

        private List<LevelButton> levelsGrid = new List<LevelButton>();

        private new void Awake()
        {
            base.Awake();

            leftArrowButton.onClick.AddListener(OnLeftArrowClicked);
            rightArrowButton.onClick.AddListener(OnRightArrowClicked);
        }

        private void OnDestroy()
        {

        }

        private void OnEnable()
        {
            
        }

        //private void SetLevelsGrid(List<LevelData> levels)
        //{
        //    int difference = levels.Count - levelsGrid.Count;

        //    if (difference > 0)
        //    {
        //        for (int i = 0; i < difference; i++)
        //        {
        //            LevelButton levelButton = Instantiate(levelPrefab, levelsParent).GetComponent<LevelButton>();
        //            levelsGrid.Add(levelButton);
        //        }
        //    }
        //    else if (difference < 0)
        //    {
        //        int invertDiff = difference * (-1);

        //        for (int i = 0; i < invertDiff; i++)
        //        {
        //            levelsGrid[levelsGrid.Count - (1 + i)].gameObject.SetActive(false);
        //        }
        //    }

        //    for (int i = 0; i < levels.Count; i++)
        //    {
        //        levelsGrid[i].Initialize(levels[i]);
        //        levelsGrid[i].gameObject.SetActive(true);
        //    }
        //}

        private void OnLeftArrowClicked()
        {
            
        }

        private void OnRightArrowClicked()
        {
            
        }
    }

}