using MenuManager.Scripts.Components.NonInteractive.Extensions;
using PetrushevskiApps.UIManager;
using TMPro;
using UnityEngine;
using Zenject;

namespace slowBulletGames.MemoryValley
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

        // Injected
        protected ILevelCompletedScreenViewModel ViewModel;

        [Inject]
        private void Initialize(ILevelCompletedScreenViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override void Show<TArguments>(TArguments navArguments)
        {
            base.Show(navArguments);
            if (navArguments is LevelCompletedArguments arguments)
            {
                ViewModel.SetEarnedCoins(arguments.EarnedCoins);
            }
        }

        public override void Resume()
        {
            base.Resume();
            _replayButton.OnClick.AddListener(ViewModel.ReplayButtonClicked);
            _homeButton.OnClick.AddListener(ViewModel.HomeButtonClicked);
            _settingsButton.OnClick.AddListener(ViewModel.SettingsButtonClicked);
            _nextButton.OnClick.AddListener(ViewModel.NextLevelButtonClicked);
            _doubleRewardButton.OnClick.AddListener(ViewModel.DoubleRewardButtonClicked);
            ViewModel.StarsAchieved.Subscribe(_stars.SetData);
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
            ViewModel.StarsAchieved.Unsubscribe(_stars.SetData);
            ViewModel.Title.Unsubscribe(_title.SetData);
            ViewModel.EarnedCoinsText.Subscribe(_earnedCoinsText.SetData);
        }

        public override void OnBackTriggered()
        {
            ViewModel.OnBackTriggered();
        }
    }
}