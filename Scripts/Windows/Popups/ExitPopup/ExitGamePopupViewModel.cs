using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class ExitGamePopupViewModel : IExitGamePopupViewModel
    {
        private readonly IExitAppController _exitAppController;

        // Injected
        private readonly INavigationController _navigationController;

        public ExitGamePopupViewModel(
            INavigationController navigationController,
            IExitAppController exitAppController)
        {
            _navigationController = navigationController;
            _exitAppController = exitAppController;
        }

        // Reactive Properties
        public IReactiveProperty<string> Title { get; protected set; }
        public IReactiveProperty<string> Message { get; protected set; }

        public void BackgroundClicked()
        {
            _navigationController.GoBack();
        }

        public void DiscardPopupClicked()
        {
            _navigationController.GoBack();
        }

        public void ExitApp()
        {
            _exitAppController.ExitApp();
        }
    }
}