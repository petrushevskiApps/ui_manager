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
                ViewModel.SetEarnedCoins(arguments.EarnedCoins);
                ViewModel.SetEarnedStars(arguments.EarnedStars);
                _uiHapticsController.LevelCompleted();
            }
        }

        public override void Resume()
        {
            base.Resume();
            ViewModel.ScreenResumed();
            _replayButton.OnClick.AddListener(ViewModel.ReplayButtonClicked);
            _homeButton.OnClick.AddListener(ViewModel.HomeButtonClicked);
            _settingsButton.OnClick.AddListener(ViewModel.SettingsButtonClicked);
            _nextButton.OnClick.AddListener(ViewModel.NextLevelButtonClicked);
            _doubleRewardButton.OnClick.AddListener(ViewModel.DoubleRewardButtonClicked);
            ViewModel.EarnedStars.Subscribe(_stars.SetData);
            ViewModel.Title.Subscribe(_title.SetData);
            ViewModel.EarnedCoinsText.Subscribe(_earnedCoinsText.SetData);
        }

        public override void Hide()
        {
            base.Hide();
            _replayButton.OnClick.RemoveListener(ViewModel.ReplayButtonClicked);
            _homeButton.OnClick.RemoveListener(ViewModel.HomeButtonClicked);
            _settingsButton.OnClick.RemoveListener(ViewModel.SettingsButtonClicked);
            _nextButton.OnClick.RemoveListener(ViewModel.NextLevelButtonClicked);
            _doubleRewardButton.OnClick.RemoveListener(ViewModel.DoubleRewardButtonClicked);
            ViewModel.EarnedStars.Unsubscribe(_stars.SetData);
            ViewModel.Title.Unsubscribe(_title.SetData);
            ViewModel.EarnedCoinsText.Subscribe(_earnedCoinsText.SetData);
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