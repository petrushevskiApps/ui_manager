using PetrushevskiApps.UIManager;
using UnityEngine;
using Zenject;

namespace slowBulletGames.MemoryValley
{
    public class LevelLeavePopup : UIPopup
    {
        [SerializeField]
        private UIButton _confirmButton;

        [SerializeField]
        private UIButton _discardButton;

        // Injected
        private ILevelLeavePopupViewModel _viewModel;

        protected override IPopupViewModel GetPopupViewModel() => _viewModel;
        
        [Inject]
        private void Initialize(ILevelLeavePopupViewModel viewModel)
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
            _viewModel.ExitLevel();
        }

        private void DiscardButtonClicked()
        {
            Close();
            _viewModel.DiscardPopupClicked();
        }
    }
}