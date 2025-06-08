using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    internal class ExitLevelPopupViewModel : IExitLevelPopupViewModel
    {
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

        // Reactive Properties
        public IReactiveProperty<string> Title { get; }
        public IReactiveProperty<string> Message { get; }

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