using TwoOneTwoGames.UIManager.Components.NonInteractive;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    public sealed class InGameScreenViewModel : IInGameScreenViewModel
    {
        // Injected
        private readonly IPopupNavigation _popupNavigation;

        public InGameScreenViewModel(IPopupNavigation popupNavigation)
        {
            _popupNavigation = popupNavigation;
            LevelTitle = new ReactiveProperty<string>("");
            ProgressBarData = new ReactiveProperty<UIProgressBarData>();
        }

        public IReactiveProperty<string> LevelTitle { get; }
        public IReactiveProperty<UIProgressBarData> ProgressBarData { get; }

        public void PauseClicked()
        {
            _popupNavigation.ShowPausePopup();
        }

        public void OnBackTriggered()
        {
            _popupNavigation.ShowExitLevelPopup();
        }
    }
}