using PetrushevskiApps.UIManager;
using UnityEngine;
using Zenject;

namespace slowBulletGames.MemoryValley
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

        protected override IPopupViewModel GetPopupViewModel() => _viewModel;
        
        [Inject]
        private void Initialize(IPausePopupViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        private void Awake()
        {
            _restartButton.onClick.AddListener(OnRestartClicked);
            _homeButton.onClick.AddListener(OnHomeClicked);
            _playButton.onClick.AddListener(OnPlayClicked);
            _settingsButton.onClick.AddListener(OnSettingsClicked);
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