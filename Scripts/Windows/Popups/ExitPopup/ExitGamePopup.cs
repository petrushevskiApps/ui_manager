using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class ExitGamePopup : UIPopup
    {
        [SerializeField]
        private UIButton _confirmButton;

        [SerializeField]
        private UIButton _discardButton;

        // Injected
        private IExitGamePopupViewModel _viewModel;

        protected override IPopupViewModel GetPopupViewModel()
        {
            return _viewModel;
        }

        [Inject]
        private void Initialize(IExitGamePopupViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Resume()
        {
            base.Resume();
            _viewModel.ConfirmButton.Subscribe(_confirmButton.SetData);
            _viewModel.DiscardButton.Subscribe(_discardButton.SetData);
        }

        public override void Hide()
        {
            base.Hide();
            _viewModel.ConfirmButton.Unsubscribe(_confirmButton.SetData);
            _viewModel.DiscardButton.Unsubscribe(_discardButton.SetData);
        }
    }
}