namespace slowBulletGames.MemoryValley
{
    /// <summary>
    /// This is a interface for the exit popup.
    /// Concrete implementation should be provided
    /// with the app using this toolkit.
    /// </summary>
    public interface IExitPopupViewModel: IPopupViewModel
    {
        void DiscardPopupClicked();
        void ExitApp();
    }
}