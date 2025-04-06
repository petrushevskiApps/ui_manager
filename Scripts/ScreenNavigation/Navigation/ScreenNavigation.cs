using slowBulletGames.MemoryValley;

namespace PetrushevskiApps.UIManager.ScreenNavigation.Navigation
{
    public class ScreenNavigation: IScreenNavigation
    {
        private readonly INavigationController _navigationController;

        public ScreenNavigation(INavigationController navigationController)
        {
            _navigationController = navigationController;
        }
        public void ShowMainScreen()
        {
            _navigationController.ShowScreen<MainScreen>();
        }

        public void ShowInGameScreen()
        {
            _navigationController.ShowScreen<InGameScreen>();
        }

        public void ShowLevelCompletedScreen(LevelCompletedArguments arguments)
        {
            _navigationController.ShowScreen<LevelCompletedScreen, LevelCompletedArguments>(arguments);
        }

        public void ShowLevelFailedScreen()
        {
            _navigationController.ShowScreen<LevelFailedScreen>();
        }
    }
}