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

        public override void Resume()
        {
            base.Resume();
            _replayButton.onClick.AddListener(ViewModel.ReplayButtonClicked);
            _homeButton.onClick.AddListener(ViewModel.HomeButtonClicked);
            _settingsButton.onClick.AddListener(ViewModel.SettingsButtonClicked);
            _nextButton.onClick.AddListener(ViewModel.NextLevelButtonClicked);
            _doubleRewardButton.onClick.AddListener(ViewModel.DoubleRewardButtonClicked);
            ViewModel.StarsAchieved.Subscribe(_stars.SetData);
            ViewModel.Title.Subscribe(_title.Update);
        }

        public override void Hide()
        {
            base.Hide();
            _replayButton.onClick.RemoveListener(ViewModel.ReplayButtonClicked);
            _homeButton.onClick.RemoveListener(ViewModel.HomeButtonClicked);
            _settingsButton.onClick.RemoveListener(ViewModel.SettingsButtonClicked);
            _nextButton.onClick.RemoveListener(ViewModel.NextLevelButtonClicked);
            _doubleRewardButton.onClick.RemoveListener(ViewModel.DoubleRewardButtonClicked);
            ViewModel.StarsAchieved.Unsubscribe(_stars.SetData);
            ViewModel.Title.Unsubscribe(_title.Update);
        }

        public override void OnBackTriggered()
        {
            ViewModel.OnBackTriggered();
        }
    }
}