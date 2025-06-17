using TMPro;
using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.Components.NonInteractive;
using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Windows
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

        [Inject]
        public void Initialize(
            IInGameScreenViewModel viewModel,
            IUILevelController uiLevelController)
        {
            ViewModel = viewModel;
        }

        public override void Resume()
        {
            base.Resume();
            _pauseButton.OnClick.AddListener(ViewModel.PauseClicked);
            ViewModel.LevelTitle.Subscribe(SetLevelTitle);
            if (_progressBar != null)
            {
                ViewModel.ProgressBarData.Subscribe(_progressBar.SetData);
            }
            ViewModel.ScreenResumed();
        }

        public override void Hide()
        {
            base.Hide();
            _pauseButton.OnClick.RemoveListener(ViewModel.PauseClicked);
            ViewModel.LevelTitle.Unsubscribe(SetLevelTitle);
            if (_progressBar != null)
            {
                ViewModel.ProgressBarData.Unsubscribe(_progressBar.SetData);
            }
            ViewModel.ScreenHidden();
        }

        private void SetLevelTitle(string title)
        {
            _levelTitle.text = title;
        }

        public override void OnBackTriggered()
        {
            ViewModel.OnBackTriggered();
        }
    }
}