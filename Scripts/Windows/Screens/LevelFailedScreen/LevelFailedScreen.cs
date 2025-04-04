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
        
        [Inject]
        private void Initialize(ILevelFailedScreenViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override void Resume()
        {
            base.Resume();
            _reviveButton.OnClick.AddListener(ViewModel.ReviveButtonClicked);
            _replayButton.OnClick.AddListener(ViewModel.ReplayButtonClicked);
            _homeButton.OnClick.AddListener(ViewModel.HomeButtonClicked);
            _settingsButton.OnClick.AddListener(ViewModel.SettingsClicked);
        }

        public override void Hide()
        {
            base.Hide();
            _reviveButton.OnClick.RemoveListener(ViewModel.ReviveButtonClicked);
            _replayButton.OnClick.RemoveListener(ViewModel.ReplayButtonClicked);
            _homeButton.OnClick.RemoveListener(ViewModel.HomeButtonClicked);
            _settingsButton.OnClick.RemoveListener(ViewModel.SettingsClicked);
        }
        
        public override void OnBackTriggered()
        {
            ViewModel.OnBackTriggered();
        }
    }
}