using MenuManager.Scripts.Utilitis;

namespace slowBulletGames.MemoryValley
{
    public class ExitGamePopupViewModel : IExitGamePopupViewModel
    {
        // Reactive Properties
        public IReactiveProperty<string> Title { get; protected set; }
        public IReactiveProperty<string> Message { get; protected set; }

        // Injected
        private readonly INavigationController _navigationController;
        private readonly IExitAppController _exitAppController;

        public ExitGamePopupViewModel(
            INavigationController navigationController,
            IExitAppController exitAppController)
        {
            _navigationController = navigationController;
            _exitAppController = exitAppController;
        }

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