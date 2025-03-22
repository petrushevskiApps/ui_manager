using MenuManager.Scripts.Utilitis;

namespace slowBulletGames.MemoryValley
{
    class ExitLevelPopupViewModel : IExitLevelPopupViewModel
    {
        // Reactive Properties
        public IReactiveProperty<string> Title { get; }
        public IReactiveProperty<string> Message { get; }
        
        // Injected
        private readonly INavigationController _navigationController;
        private readonly IUILevelController _uiLevelController;

        public ExitLevelPopupViewModel(
            INavigationController navigationController,
            IUILevelController uiLevelController)
        {
            _navigationController = navigationController;
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
            _navigationController.ShowScreen<MainScreen>();
        }

        public void DiscardPopupClicked()
        {
            _navigationController.GoBack();
        }
    }
}