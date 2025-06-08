using TwoOneTwoGames.UIManager.Windows;

namespace TwoOneTwoGames.UIManager
{
    /// <summary>
    ///     This is a interface for the Level Abandon popup.
    ///     Concrete implementation should be provided
    ///     with the app using this toolkit.
    /// </summary>
    public interface IExitLevelPopupViewModel : IPopupViewModel
    {
        void ExitLevel();
        void DiscardPopupClicked();
    }
}