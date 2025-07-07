using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    /// <summary>
    ///     This is a interface for the No Internet popup.
    ///     Concrete implementation should be provided
    ///     with the app using this toolkit.
    /// </summary>
    public interface INoInternetPopupViewModel : IPopupViewModel
    {
        public void OkButtonClicked();
        IReactiveProperty<UIButtonViewData> OkButton { get; }
    }
}