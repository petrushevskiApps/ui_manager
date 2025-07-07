using TMPro;
using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.Components.NonInteractive;
using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class LevelCompletedScreen : UIScreen
    {
        [SerializeField]
        private UIStars _stars;

        [SerializeField]
        private TextMeshProUGUI _title;

        [SerializeField]
        private TextMeshProUGUI _earnedCoinsText;

        [Header("Buttons")]
        [SerializeField]
        private UIButton _replayButton;

        [SerializeField]
        private UIButton _homeButton;

        [SerializeField]
        private UIButton _settingsButton;

        [SerializeField]
        private UIButton _nextButton;

        [SerializeField]
        private UIButton _doubleRewardButton;

        private IUiHapticsController _uiHapticsController;

        // Injected
        protected ILevelCompletedScreenViewModel ViewModel;

        [Inject]
        private void Initialize(
            ILevelCompletedScreenViewModel viewModel,
            IUiHapticsController uiHapticsController)
        {
            ViewModel = viewModel;
            _uiHapticsController = uiHapticsController;
        }

        public override void Show<TArguments>(TArguments navArguments)
        {
            base.Show(navArguments);
            if (navArguments is LevelCompletedArguments arguments)
            {
                ViewModel.SetEarnedPoints(arguments.EarnedPoints);
                ViewModel.SetEarnedStars(arguments.EarnedStars);
                _uiHapticsController.LevelCompleted();
            }
        }

        public override void Resume()
        {
            base.Resume();
            ViewModel.ScreenResumed();
            
            ViewModel.ReplayButton.Subscribe(_replayButton.SetData);
            ViewModel.HomeButton.Subscribe(_homeButton.SetData);
            ViewModel.SettingsButton.Subscribe(_settingsButton.SetData);
            ViewModel.NextButton.Subscribe(_nextButton.SetData);
            ViewModel.DoubleRewardButton.Subscribe(_doubleRewardButton.SetData);
            
            ViewModel.EarnedStars.Subscribe(_stars.SetData);
            ViewModel.Title.Subscribe(_title.SetData);
            if (_earnedCoinsText != null)
            {
                ViewModel.EarnedCoinsText.Subscribe(_earnedCoinsText.SetData);
            }
        }

        public override void Hide()
        {
            base.Hide();
            
            ViewModel.ReplayButton.Unsubscribe(_replayButton.SetData);
            ViewModel.HomeButton.Unsubscribe(_homeButton.SetData);
            ViewModel.SettingsButton.Unsubscribe(_settingsButton.SetData);
            ViewModel.NextButton.Unsubscribe(_nextButton.SetData);
            ViewModel.DoubleRewardButton.Unsubscribe(_doubleRewardButton.SetData);
            
            ViewModel.EarnedStars.Unsubscribe(_stars.SetData);
            ViewModel.Title.Unsubscribe(_title.SetData);
            if (_earnedCoinsText != null)
            {
                ViewModel.EarnedCoinsText.Subscribe(_earnedCoinsText.SetData);
            }
            ViewModel.ScreenHidden();
        }

        public override void Close()
        {
            base.Close();
            ViewModel.ScreenClosed();
        }

        public override void OnBackTriggered()
        {
            ViewModel.OnBackTriggered();
        }
    }
}