namespace slowBulletGames.MemoryValley
{
    public class MainScreenViewModel: IMainScreenViewModel
    {
        // Injected
        protected readonly INavigationController NavigationController;
        private readonly IUILevelController _uiLevelController;

        public MainScreenViewModel(
            INavigationController navigationController,
            IUILevelController uiLevelController)
        {
            NavigationController = navigationController;
            _uiLevelController = uiLevelController;
        }

        public virtual void SettingsClicked()
        {
            NavigationController.ShowPopup<SettingsPopup>();
        }

        public virtual void StartLevelClicked()
        {
            _uiLevelController.StartLevel();
            // NavigationController.ShowScreen<InGameScreen>();
        }

        public virtual void OnBackTriggered()
        {
            NavigationController.ShowPopup<ExitGamePopup>();
        }
    }
}