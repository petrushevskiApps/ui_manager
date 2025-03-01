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

        public ExitLevelPopupViewModel(INavigationController navigationController)
        {
            _navigationController = navigationController;
            Title = new ReactiveProperty<string>("Exit Level");
            Message = new ReactiveProperty<string>("Are you sure? \nYour progress will be lost.");
        }
        public void BackgroundClicked()
        {
            _navigationController.GoBack();
        }

        public void ExitLevel()
        {
            _navigationController.ShowScreen<MainScreen>();
        }

        public void DiscardPopupClicked()
        {
            _navigationController.GoBack();
        }
    }
}