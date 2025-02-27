namespace slowBulletGames.MemoryValley
{
    /// <summary>
    /// This is a interface for the Pause popup.
    /// Concrete implementation should be provided
    /// with the app using this toolkit.
    /// </summary>
    public interface IPausePopupViewModel : IPopupViewModel
    {
        void RestartClicked();
        void HomeClicked();
        void PlayClicked();
        void SettingsClicked();
    }
}