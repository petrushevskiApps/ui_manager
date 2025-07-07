using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    /// <summary>
    ///     This is a interface for the Pause popup.
    ///     Concrete implementation should be provided
    ///     with the app using this toolkit.
    /// </summary>
    public interface IPausePopupViewModel : IPopupViewModel
    {
        IReactiveProperty<UIButtonViewData> RestartButton { get; }
        IReactiveProperty<UIButtonViewData> HomeButton { get; }
        IReactiveProperty<UIButtonViewData> PlayButton { get; }
        IReactiveProperty<UIButtonViewData> SettingsButton { get; }
    }
}