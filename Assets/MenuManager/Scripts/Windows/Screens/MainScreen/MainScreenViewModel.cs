namespace slowBulletGames.MemoryValley
{
    public class MainScreenViewModel: IMainScreenViewModel
    {
        // Injected
        protected readonly INavigationController NavigationController;
        private readonly IUILevelControlled _uiLevelControlled;

        public MainScreenViewModel(
            INavigationController navigationController,
            IUILevelControlled uiLevelControlled)
        {
            NavigationController = navigationController;
            _uiLevelControlled = uiLevelControlled;
        }

        public virtual void SettingsClicked()
        {
            NavigationController.ShowPopup<SettingsPopup>();
        }

        public virtual void StartLevelClicked()
        {
            _uiLevelControlled.StartNextLevel();
            NavigationController.ShowScreen<InGameScreen>();
        }

        public virtual void OnBackTriggered()
        {
            NavigationController.ShowPopup<ExitGamePopup>();
        }
    }
}