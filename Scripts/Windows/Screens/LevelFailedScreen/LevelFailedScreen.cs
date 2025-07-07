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
            
            ViewModel.ReplayButton.Subscribe(_reviveButton.SetData);
            ViewModel.ReplayButton.Subscribe(_replayButton.SetData);
            ViewModel.HomeButton.Subscribe(_homeButton.SetData);
            ViewModel.SettingsButton.Subscribe(_settingsButton.SetData);
            
            _uiHapticsController.LevelFailed();
            ViewModel.ScreenShown();
        }

        public override void Hide()
        {
            base.Hide();
            
            ViewModel.ReplayButton.Unsubscribe(_reviveButton.SetData);
            ViewModel.ReplayButton.Unsubscribe(_replayButton.SetData);
            ViewModel.HomeButton.Unsubscribe(_homeButton.SetData);
            ViewModel.SettingsButton.Unsubscribe(_settingsButton.SetData);

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