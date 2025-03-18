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
            _settingsButton.onClick.AddListener(_viewModel.SettingsClicked);
            _startButton.onClick.AddListener(_viewModel.StartLevelClicked);
        }

        public override void Hide()
        {
            base.Hide();
            _settingsButton.onClick.RemoveListener(_viewModel.SettingsClicked);
            _startButton.onClick.RemoveListener(_viewModel.StartLevelClicked);
        }

        public override void OnBackTriggered()
        {
            _viewModel.OnBackTriggered();
        }
    }
}