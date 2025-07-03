using System;
using System.Collections.Generic;
using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.Windows;

namespace TwoOneTwoGames.UIManager.Components.Interactive.LevelsList
{
    public interface ILevelsListViewModel
    {
        public List<IUILevelData> Levels { get; }
        public event EventHandler<PageLoadedEventArguments> PageLoadedEvent;
        public void Setup();
        void LoadNextPage();
        void OnLevelClicked(int funnelId, int levelId);
    }
}