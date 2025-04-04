using PetrushevskiApps.UIManager;
using UnityEngine;
using Zenject;

namespace slowBulletGames.MemoryValley
{
    public class ExitLevelPopup : UIPopup
    {
        [SerializeField]
        private UIButton _confirmButton;

        [SerializeField]
        private UIButton _discardButton;

        // Injected
        private IExitLevelPopupViewModel _viewModel;

        protected override IPopupViewModel GetPopupViewModel() => _viewModel;
        
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