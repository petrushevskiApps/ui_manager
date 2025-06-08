using System;
using System.Collections.Generic;
using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class LevelsScreenViewModel : ILevelsScreenViewModel
    {
        private const int PAGE_SIZE = 10;
    
        // Reactive Properties
        public event EventHandler<PageLoadedEventArguments> PageLoadedEvent;
        public IReactiveProperty<string> Title { get; }
        public IReactiveProperty<int> LastCompletedLevelIndex { get; }
        public List<IUILevelData> Levels { get; private set; } = new();

        // Injected
        private readonly IScreenNavigation _screenNavigation;
        private readonly ILevelsDataProvider _levelsDataProvider;
        private readonly IUILevelController _levelController;
        private bool _allPagesFetched;
        private int _currentPage;

        public LevelsScreenViewModel(
            IScreenNavigation screenNavigation,
            ILevelsDataProvider levelsDataProvider,
            IUILevelController levelController)
        {
            _screenNavigation = screenNavigation;
            _levelsDataProvider = levelsDataProvider;
            _levelController = levelController;

            Title = new ReactiveProperty<string>("Levels");
            LastCompletedLevelIndex = new ReactiveProperty<int>();
        }
        public void ScreenResumed()
        {
            _currentPage = 0;
            _allPagesFetched = false;
            Levels.Clear();
        }
    
        public void OnBackTriggered()
        {
            _screenNavigation.NavigateBack();
        }

        public void LoadNextPage()
        {
            if (_allPagesFetched)
            {
                return;
            }

            List<IUILevelData> loadedPage = _levelsDataProvider.GetLevels(_currentPage, PAGE_SIZE);
            _currentPage++;
            if (loadedPage.Count < PAGE_SIZE)
            {
                _allPagesFetched = true;
            }

            Levels.AddRange(loadedPage);
            PageLoadedEvent?.Invoke(this, new PageLoadedEventArguments(GetIndexOfLevelToScroll(), loadedPage.Count));
        }

        public void OnLevelClicked(int funnelId, int levelId)
        {
            _levelController.StartLevel(funnelId, levelId);
        }

        private int GetIndexOfLevelToScroll()
        {
            IUILevelData levelData = _levelsDataProvider.GetLastUnlockedLevel();
            int index = Levels.FindIndex(ld => levelData.Id == ld.Id);
            return Math.Clamp(index - 1, 0, Levels.Count);
        }
    }
}