namespace slowBulletGames.MemoryValley
{
    /// <summary>
    /// This is a interface for the Level Completed popup.
    /// Concrete implementation should be provided
    /// with the app using this toolkit.
    /// </summary>
    public interface ILevelCompletedScreenViewModel
    {
        void NextLevelButtonClicked();
        void ReplayButtonClicked();
        void HomeButtonClicked();
    }
}