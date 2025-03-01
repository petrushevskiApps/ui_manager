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
        protected IMainScreenViewModel ViewModel;

        protected override IBackButtonHandler BackButtonHandler() => ViewModel;

        [Inject]
        public void Initialize(IMainScreenViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override void Resume()
        {
            base.Resume();
            _settingsButton.onClick.AddListener(ViewModel.SettingsClicked);
            _startButton.onClick.AddListener(ViewModel.StartLevelClicked);
        }

        public override void Hide()
        {
            base.Hide();
            _settingsButton.onClick.RemoveListener(ViewModel.SettingsClicked);
            _startButton.onClick.RemoveListener(ViewModel.StartLevelClicked);
        }
    }
}