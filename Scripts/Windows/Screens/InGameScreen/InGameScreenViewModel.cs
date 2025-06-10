using TwoOneTwoGames.UIManager.Components.NonInteractive;
using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    public sealed class InGameScreenViewModel : IInGameScreenViewModel
    {
        // Reactive Properties
        public IReactiveProperty<string> LevelTitle { get; }
        public IReactiveProperty<UIProgressBarData> ProgressBarData { get; }

        // Injected
        private readonly IPopupNavigation _popupNavigation;
        private IUILevelController _uiLevelController;

        public InGameScreenViewModel(
            IPopupNavigation popupNavigation,
            IUILevelController uiLevelController)
        {
            _popupNavigation = popupNavigation;
            _uiLevelController = uiLevelController;

            LevelTitle = new ReactiveProperty<string>("");
            ProgressBarData = new ReactiveProperty<UIProgressBarData>();
        }

        public void ScreenResumed()
        {
            _uiLevelController.LevelStartedEvent += OnLevelStarted;
        }

        public void ScreenHidden()
        {
            _uiLevelController.LevelStartedEvent -= OnLevelStarted;
        }

        private void OnLevelStarted(object sender, string levelTitle)
        {
            LevelTitle.Value = $"Level {levelTitle}";
        }

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