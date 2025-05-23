using MenuManager.Scripts.Utilitis;

namespace slowBulletGames.MemoryValley
{
    /// <summary>
    /// This is a interface for the Level Completed popup.
    /// Concrete implementation should be provided
    /// with the app using this toolkit.
    /// </summary>
    public interface ILevelCompletedScreenViewModel
    {
        IReactiveProperty<int> EarnedStars { get; }
        IReactiveProperty<string> Title { get; }
        IReactiveProperty<string> EarnedCoinsText { get; }
        void NextLevelButtonClicked();
        void ReplayButtonClicked();
        void HomeButtonClicked();
        void DoubleRewardButtonClicked();
        void SettingsButtonClicked();
        void OnBackTriggered();
        void SetEarnedCoins(int coins);
        void SetEarnedStars(int earnedStars);
        void ScreenResumed();
        void ScreenHidden();
    }
}