using System;
using System.Collections.Generic;
using TwoOneTwoGames.UIManager.InfiniteScrollList;
using TwoOneTwoGames.UIManager.Interfaces;
using UnityEngine;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class ListRowView: MonoBehaviour, IItemView
    {
        [SerializeField]
        private List<LevelItemView> _rowViews;
        
        public int Index { get; set; }
        public GameObject View => gameObject;

        public void SetData(
            IUiHapticsController uiHapticsController, 
            Action<int, int> onClick,
            bool isFunnelUnlocked,
            params IUILevelData[] levels)
        {
            if (levels.Length > _rowViews.Count)
            {
                Debug.LogError("Mismatch in number of Row Views and Levels Data provided.");
                return;
            }
            _rowViews.ForEach(view => view.gameObject.SetActive(false));
            for (int i = 0; i < levels.Length; i++)
            {
                _rowViews[i].SetData(
                    uiHapticsController,
                    levels[i],
                    isFunnelUnlocked,
                    onClick);
            }
        }

    }
}