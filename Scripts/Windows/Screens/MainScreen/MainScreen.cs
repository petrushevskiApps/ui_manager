using PetrushevskiApps.UIManager;
using UnityEngine;
using Zenject;

namespace slowBulletGames.MemoryValley
{
    public class MainScreen : UIScreen
    {
        [Header("Buttons")]
        [SerializeField]
        private UIButton _settingsButton;

        [SerializeField]
        private UIButton _startButton;

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
            _settingsButton.OnClick.AddListener(_viewModel.SettingsClicked);
            _startButton.OnClick.AddListener(_viewModel.StartLevelClicked);
        }

        public override void Hide()
        {
            base.Hide();
            _settingsButton.OnClick.RemoveListener(_viewModel.SettingsClicked);
            _startButton.OnClick.RemoveListener(_viewModel.StartLevelClicked);
        }

        public override void OnBackTriggered()
        {
            _viewModel.OnBackTriggered();
        }
    }
}