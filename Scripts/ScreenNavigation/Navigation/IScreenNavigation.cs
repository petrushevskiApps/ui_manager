namespace PetrushevskiApps.UIManager.ScreenNavigation.Navigation
{
    public interface IScreenNavigation
    {
        public void ShowMainScreen();
        public void ShowInGameScreen();
        public void ShowLevelCompletedScreen();
        public void ShowLevelFailedScreen();
    }
}