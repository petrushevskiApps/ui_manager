﻿using MenuManager.Scripts.Utilitis;
using PetrushevskiApps.UIManager.ScreenNavigation.Navigation;

namespace slowBulletGames.MemoryValley
{
    class ExitLevelPopupViewModel : IExitLevelPopupViewModel
    {
        // Reactive Properties
        public IReactiveProperty<string> Title { get; }
        public IReactiveProperty<string> Message { get; }

        // Injected
        private readonly INavigationController _navigationController;
        private readonly IScreenNavigation _screenNavigation;
        private readonly IUILevelController _uiLevelController;

        public ExitLevelPopupViewModel(
            INavigationController navigationController,
            IScreenNavigation screenNavigation,
            IUILevelController uiLevelController)
        {
            _navigationController = navigationController;
            _screenNavigation = screenNavigation;
            _uiLevelController = uiLevelController;

            Title = new ReactiveProperty<string>("Exit Level");
            Message = new ReactiveProperty<string>("Are you sure? \nYour progress will be lost.");
        }

        public void BackgroundClicked()
        {
            _navigationController.GoBack();
        }

        public void ExitLevel()
        {
            _uiLevelController.LeaveLevel();
            _screenNavigation.ShowMainScreen();
        }

        public void DiscardPopupClicked()
        {
            _navigationController.GoBack();
        }
    }
}