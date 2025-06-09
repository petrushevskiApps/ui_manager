using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    public interface IMainScreenViewModel
    {
        IReactiveProperty<UIButtonViewData> PlayButton { get; }
        void SettingsClicked();
        void StartLevelClicked();
        void OnBackTriggered();
        void ScreenResumed();
        void ScreenHidden();
        void LevelsButtonClicked();
    }
}