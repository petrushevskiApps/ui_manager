namespace slowBulletGames.MemoryValley
{
    public class LevelFailedScreenViewModel : ILevelFailedScreenViewModel
    {
        // Injected
        protected readonly INavigationController NavigationController;
        private readonly IUILevelController _uiLevelController;

        public LevelFailedScreenViewModel(
            INavigationController navigationController,
            IUILevelController uiLevelController)
        {
            NavigationController = navigationController;
            _uiLevelController = uiLevelController;
        }
        
        public virtual void OnBackTriggered()
        {
            NavigationController.ShowScreen<MainScreen>();
        }

        public virtual void HomeButtonClicked()
        {
            NavigationController.ShowScreen<MainScreen>();
        }

        public virtual void ReplayButtonClicked()
        {
            _uiLevelController.RestartLevel();
        }

        public virtual void ReviveButtonClicked()
        {
            _uiLevelController.ReviveAndContinueLevel();
        }

        public void SettingsClicked()
        {
            NavigationController.ShowPopup<SettingsPopup>();
        }
    }
}