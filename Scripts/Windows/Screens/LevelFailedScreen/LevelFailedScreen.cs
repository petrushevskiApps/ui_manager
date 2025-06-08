using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Windows
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

        private IUiHapticsController _uiHapticsController;

        // Injected
        protected ILevelFailedScreenViewModel ViewModel;

        [Inject]
        private void Initialize(
            ILevelFailedScreenViewModel viewModel,
            IUiHapticsController uiHapticsController)
        {
            ViewModel = viewModel;
            _uiHapticsController = uiHapticsController;
        }

        public override void Resume()
        {
            base.Resume();
            _reviveButton.OnClick.AddListener(ViewModel.ReviveButtonClicked);
            _replayButton.OnClick.AddListener(ViewModel.ReplayButtonClicked);
            _homeButton.OnClick.AddListener(ViewModel.HomeButtonClicked);
            _settingsButton.OnClick.AddListener(ViewModel.SettingsClicked);
            _uiHapticsController.LevelFailed();
            ViewModel.ScreenShown();
        }

        public override void Hide()
        {
            base.Hide();
            _reviveButton.OnClick.RemoveListener(ViewModel.ReviveButtonClicked);
            _replayButton.OnClick.RemoveListener(ViewModel.ReplayButtonClicked);
            _homeButton.OnClick.RemoveListener(ViewModel.HomeButtonClicked);
            _settingsButton.OnClick.RemoveListener(ViewModel.SettingsClicked);
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