using PetrushevskiApps.UIManager;
using TMPro;
using UnityEngine;
using Zenject;

namespace slowBulletGames.MemoryValley
{
    public class InGameScreen : UIScreen
    {
        [SerializeField]
        private TextMeshProUGUI _levelTitle;
        [SerializeField]
        private UIProgressBar _progressBar;
        [SerializeField]
        private UIButton _pauseButton;

        // [SerializeField]
        // private UIButton _hintButton;

        // Injected
        protected IInGameScreenViewModel ViewModel;

        protected override IBackButtonHandler BackButtonHandler() => ViewModel;

        [Inject]
        public void Initialize(IInGameScreenViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override void Resume()
        {
            base.Resume();
            _pauseButton.onClick.AddListener(ViewModel.PauseClicked);
            ViewModel.LevelTitle.Subscribe(SetLevelTitle);
            ViewModel.ProgressBarData.Subscribe(_progressBar.SetData);
        }

        public override void Hide()
        {
            base.Hide();
            _pauseButton.onClick.RemoveListener(ViewModel.PauseClicked);
            ViewModel.LevelTitle.Unsubscribe(SetLevelTitle);
            ViewModel.ProgressBarData.Unsubscribe(_progressBar.SetData);
        }

        private void SetLevelTitle(string title)
        {
            _levelTitle.text = title;
        }
    }
}