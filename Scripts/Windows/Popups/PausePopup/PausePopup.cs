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
            _restartButton.OnClick.AddListener(OnRestartClicked);
            _homeButton.OnClick.AddListener(OnHomeClicked);
            _playButton.OnClick.AddListener(OnPlayClicked);
            _settingsButton.OnClick.AddListener(OnSettingsClicked);
        }

        public override void Hide()
        {
            base.Hide();
            _restartButton.OnClick.RemoveAllListeners();
            _homeButton.OnClick.RemoveAllListeners();
            _playButton.OnClick.RemoveAllListeners();
            _settingsButton.OnClick.RemoveAllListeners();
        }

        private void OnRestartClicked()
        {
            Close();
            _viewModel.RestartClicked();
        }

        private void OnHomeClicked()
        {
            _viewModel.HomeClicked();
        }

        protected virtual void OnPlayClicked()
        {
            _viewModel.PlayClicked();
        }

        private void OnSettingsClicked()
        {
            _viewModel.SettingsClicked();
        }
    }
}