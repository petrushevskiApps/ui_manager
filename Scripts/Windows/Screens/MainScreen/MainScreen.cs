using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class MainScreen : UIScreen
    {
        [Header("Buttons")]
        [SerializeField]
        private UIButton _settingsButton;
        [SerializeField]
        private UIButton _startButton;
        [SerializeField]
        private UIButton _levelsButton;

        // Injected
        private IMainScreenViewModel _viewModel;

        [Inject]
        public void Initialize(IMainScreenViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Resume()
        {
            base.Resume();
            
            if (_levelsButton != null)
            {
                _levelsButton.OnClick.AddListener(_viewModel.LevelsButtonClicked);
            }
            if (_settingsButton != null)
            {
                _settingsButton.OnClick.AddListener(_viewModel.SettingsClicked);
            }
            if (_startButton != null)
            {
                _startButton.OnClick.AddListener(_viewModel.StartLevelClicked);
                _viewModel.PlayButton.Subscribe(_startButton.SetData);
            }
            
            _viewModel.ScreenResumed();
        }

        public override void Hide()
        {
            base.Hide();
            
            if (_levelsButton != null)
            {
                _levelsButton.OnClick.RemoveListener(_viewModel.LevelsButtonClicked);
            }
            if (_startButton != null)
            {
                _startButton.OnClick.RemoveListener(_viewModel.StartLevelClicked);
                _viewModel.PlayButton.Unsubscribe(_startButton.SetData);
            }
            if (_settingsButton != null)
            {
                _settingsButton.OnClick.RemoveListener(_viewModel.SettingsClicked);
            }
            _viewModel.ScreenHidden();
        }

        public override void OnBackTriggered()
        {
            _viewModel.OnBackTriggered();
        }
    }
}