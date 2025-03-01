using PetrushevskiApps.UIManager;
using UnityEngine;
using Zenject;

namespace slowBulletGames.MemoryValley
{
    public class LevelCompletedScreen : UIScreen
    {
        //TODO: Add UIStars here.
        // [SerializeField]
        // private GameObject _stars;

        [Header("Buttons")]
        [SerializeField]
        private UIButton _replayButton;
        [SerializeField]
        private UIButton _homeButton;
        [SerializeField]
        private UIButton _nextButton;

        // Injected
        private ILevelCompletedScreenViewModel _viewModel;

        [Inject]
        private void Initialize(ILevelCompletedScreenViewModel viewModel)
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
            _nextButton.onClick.AddListener(OnNextClicked);
        }

        public override void Resume()
        {
            base.Resume();
            SetStarsInfo();
        }

        private void SetStarsInfo()
        {
            //TODO: Implement Stars info handling once UIStars component is created.
        }

        private void OnNextClicked()
        {
            _viewModel.NextLevelButtonClicked();
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
            _viewModel.HomeButtonClicked();
        }
    }
}