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
        private void Awake()
        {
            _confirmButton.onClick.AddListener(ConfirmButtonClicked);
            _discardButton.onClick.AddListener(DiscardButtonClicked);
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