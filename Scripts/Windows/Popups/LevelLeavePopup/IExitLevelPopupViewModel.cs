using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;
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
        IReactiveProperty<UIButtonViewData> ConfirmButton { get; }
        IReactiveProperty<UIButtonViewData> DiscardButton { get; }
    }
}