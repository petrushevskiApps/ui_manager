namespace slowBulletGames.MemoryValley
{
    /// <summary>
    /// This is a interface for the Stage Completed popup.
    /// Concrete implementation should be provided
    /// with the app using this toolkit.
    /// </summary>
    public interface IStageCompletedPopupViewModel : IPopupViewModel
    {
        void HomeClicked();
        void HandleBackButtonPressed();
    }
}