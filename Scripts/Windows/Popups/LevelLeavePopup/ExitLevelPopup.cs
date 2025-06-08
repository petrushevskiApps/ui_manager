using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class ExitLevelPopup : UIPopup
    {
        [SerializeField]
        private UIButton _confirmButton;

        [SerializeField]
        private UIButton _discardButton;

        // Injected
        private IExitLevelPopupViewModel _viewModel;

        protected override IPopupViewModel GetPopupViewModel()
        {
            return _viewModel;
        }

        [Inject]
        private void Initialize(IExitLevelPopupViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Resume()
        {
            base.Resume();
            _confirmButton.OnClick.AddListener(ConfirmButtonClicked);
            _discardButton.OnClick.AddListener(DiscardButtonClicked);
        }

        public override void Hide()
        {
            base.Hide();
            _confirmButton.OnClick.RemoveAllListeners();
            _discardButton.OnClick.RemoveAllListeners();
        }

        private void ConfirmButtonClicked()
        {
            _viewModel.ExitLevel();
        }

        private void DiscardButtonClicked()
        {
            _viewModel.DiscardPopupClicked();
        }
    }
}