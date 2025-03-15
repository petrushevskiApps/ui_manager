using MenuManager.Scripts.Utilitis;

namespace slowBulletGames.MemoryValley
{
    /// <summary>
    /// This is a interface for the Level Completed popup.
    /// Concrete implementation should be provided
    /// with the app using this toolkit.
    /// </summary>
    public interface ILevelCompletedScreenViewModel: IBackButtonHandler
    {
        IReactiveProperty<int> StarsAchieved { get; }
        IReactiveProperty<string> Title { get; }
        void NextLevelButtonClicked();
        void ReplayButtonClicked();
        void HomeButtonClicked();
        void DoubleRewardButtonClicked();
        void SettingsButtonClicked();
    }
}