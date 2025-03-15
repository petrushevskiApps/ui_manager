namespace slowBulletGames.MemoryValley
{
    public class LevelFailedScreenViewModel : ILevelFailedScreenViewModel
    {
        // Injected
        protected readonly INavigationController NavigationController;
        private readonly IUILevelControlled _uiLevelControlled;

        public LevelFailedScreenViewModel(
            INavigationController navigationController,
            IUILevelControlled uiLevelControlled)
        {
            NavigationController = navigationController;
            _uiLevelControlled = uiLevelControlled;
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
            _uiLevelControlled.RestartLevel();
        }

        public virtual void ReviveButtonClicked()
        {
            _uiLevelControlled.ReviveAndContinueLevel();
        }
    }
}