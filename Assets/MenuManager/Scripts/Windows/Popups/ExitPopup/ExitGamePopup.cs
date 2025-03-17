using PetrushevskiApps.UIManager;
using UnityEngine;
using Zenject;

namespace slowBulletGames.MemoryValley
{
    public class ExitGamePopup : UIPopup
    {
        [SerializeField]
        private UIButton _confirmButton;

        [SerializeField]
        private UIButton _discardButton;

        // Injected
        private IExitGamePopupViewModel _viewModel;

        protected override IPopupViewModel GetPopupViewModel() => _viewModel;

        [Inject]
        private void Initialize(IExitGamePopupViewModel viewModel)
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
            Close();
            _viewModel.ExitApp();
        }

        private void DiscardButtonClicked()
        {
            Close();
            _viewModel.DiscardPopupClicked();
        }
    }
}