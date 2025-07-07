using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    /// <summary>
    ///     This is a interface for the Level Completed popup.
    ///     Concrete implementation should be provided
    ///     with the app using this toolkit.
    /// </summary>
    public interface ILevelCompletedScreenViewModel
    {
        IReactiveProperty<int> EarnedStars { get; }
        IReactiveProperty<string> Title { get; }
        IReactiveProperty<string> EarnedCoinsText { get; }
        IReactiveProperty<UIButtonViewData> ReplayButton { get; }
        IReactiveProperty<UIButtonViewData> HomeButton { get; }
        IReactiveProperty<UIButtonViewData> SettingsButton { get; }
        IReactiveProperty<UIButtonViewData> NextButton { get; }
        IReactiveProperty<UIButtonViewData> DoubleRewardButton { get; }
        void OnBackTriggered();
        void SetEarnedPoints(int points);
        void SetEarnedStars(int earnedStars);
        void ScreenResumed();
        void ScreenHidden();
        void ScreenClosed();
    }
}