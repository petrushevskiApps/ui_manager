using PetrushevskiApps.UIManager;
using UnityEngine;
using Zenject;

namespace slowBulletGames.MemoryValley
{
    public class LevelFailedScreen : UIScreen
    {
        [SerializeField]
        private UIButton _reviveButton;
        [SerializeField]
        private UIButton _replayButton;
        [SerializeField]
        private UIButton _homeButton;
        [SerializeField]
        private UIButton _settingsButton;

        // Injected
        protected ILevelFailedScreenViewModel ViewModel;

        protected override IBackButtonHandler BackButtonHandler() => ViewModel;

        [Inject]
        private void Initialize(ILevelFailedScreenViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override void Resume()
        {
            base.Resume();
            _reviveButton.onClick.AddListener(ViewModel.ReviveButtonClicked);
            _replayButton.onClick.AddListener(ViewModel.ReplayButtonClicked);
            _homeButton.onClick.AddListener(ViewModel.HomeButtonClicked);
            _settingsButton.onClick.AddListener(ViewModel.SettingsClicked);
        }

        public override void Hide()
        {
            base.Hide();
            _reviveButton.onClick.RemoveListener(ViewModel.ReviveButtonClicked);
            _replayButton.onClick.RemoveListener(ViewModel.ReplayButtonClicked);
            _homeButton.onClick.RemoveListener(ViewModel.HomeButtonClicked);
            _settingsButton.onClick.RemoveListener(ViewModel.SettingsClicked);
        }
    }
}