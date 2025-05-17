using slowBulletGames.MemoryValley;

namespace PetrushevskiApps.UIManager.ScreenNavigation.Navigation
{
    public interface IScreenNavigation
    {
        public void ShowMainScreen();
        public void ShowInGameScreen();
        public void ShowLevelCompletedScreen(LevelCompletedArguments levelResults);
        public void ShowLevelFailedScreen();
        void NavigateBack();
        void ShowLevelsScreen();
    }
}