using TwoOneTwoGames.UIManager.Components.NonInteractive;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    public interface IInGameScreenViewModel
    {
        IReactiveProperty<string> LevelTitle { get; }
        IReactiveProperty<UIProgressBarData> ProgressBarData { get; }
        void PauseClicked();
        void OnBackTriggered();
        void ScreenResumed();
        void ScreenHidden();
    }
}