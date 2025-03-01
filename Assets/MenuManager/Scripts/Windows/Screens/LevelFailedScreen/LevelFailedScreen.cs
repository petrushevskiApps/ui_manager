using PetrushevskiApps.UIManager;
using UnityEngine;
using Zenject;

namespace slowBulletGames.MemoryValley
{
    public class LevelFailedScreen : UIScreen
    {
        [SerializeField]
        private UIButton _replayButton;

        [SerializeField]
        private UIButton _homeButton;

        // Injected
        private ILevelFailedScreenViewModel _viewModel;
        
        [Inject]
        private void Initialize(ILevelFailedScreenViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override IBackButtonHandler BackButtonHandler()
        {
            throw new System.NotImplementedException();
        }

        private new void Awake()
        {
            base.Awake();
            _replayButton.onClick.AddListener(OnReplayClicked);
            _homeButton.onClick.AddListener(OnHomeClicked);
        }

        private void OnReplayClicked()
        {
            _viewModel.ReplayButtonClicked();
        }

        private void OnHomeClicked()
        {
            _viewModel.HomeButtonClicked();
        }

        protected override void OnBackButton()
        {
            _viewModel.BackClicked();
        }
    }
}