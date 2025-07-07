using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class PausePopup : UIPopup
    {
        [Header("Buttons")]
        [SerializeField]
        private UIButton _restartButton;

        [SerializeField]
        private UIButton _homeButton;

        [SerializeField]
        private UIButton _playButton;

        [SerializeField]
        private UIButton _settingsButton;

        // Injected
        private IPausePopupViewModel _viewModel;

        protected override IPopupViewModel GetPopupViewModel()
        {
            return _viewModel;
        }

        [Inject]
        private void Initialize(IPausePopupViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Resume()
        {
            base.Resume();
            
            _viewModel.RestartButton.Subscribe(_restartButton.SetData);
            _viewModel.HomeButton.Subscribe(_homeButton.SetData);
            _viewModel.PlayButton.Subscribe(_playButton.SetData);
            _viewModel.SettingsButton.Subscribe(_settingsButton.SetData);
        }

        public override void Hide()
        {
            base.Hide();
            _viewModel.RestartButton.Unsubscribe(_restartButton.SetData);
            _viewModel.HomeButton.Unsubscribe(_homeButton.SetData);
            _viewModel.PlayButton.Unsubscribe(_playButton.SetData);
            _viewModel.SettingsButton.Unsubscribe(_settingsButton.SetData);
        }
    }
}