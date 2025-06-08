using System;
using System.Collections.Generic;
using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    public interface ILevelsScreenViewModel
    {
        IReactiveProperty<string> Title { get; }
        public List<IUILevelData> Levels { get; }
        public event EventHandler<PageLoadedEventArguments> PageLoadedEvent;
        public void ScreenResumed();
        void OnBackTriggered();
        void LoadNextPage();
        void OnLevelClicked(int funnelId, int levelId);
    }
}