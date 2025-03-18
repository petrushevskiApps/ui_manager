using PetrushevskiApps.UIManager;
using UnityEngine;
using Zenject;

namespace slowBulletGames.MemoryValley
{
    /// <summary>
    /// Stage Completed Popup is shown when Stage is completed.
    /// Stage is a group of levels, for example Stage is Lava World
    /// and all levels set in the Lava World are in this group / stage.
    /// </summary>
    public class StageCompletedPopup : UIPopup
    {
        [SerializeField]
        private UIButton _homeButton;

        // Injected
        private IStageCompletedPopupViewModel _viewModel;

        protected override IPopupViewModel GetPopupViewModel() => _viewModel;
        
        [Inject]
        private void Initialize(IStageCompletedPopupViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        private void Awake()
        {
            _homeButton.onClick.AddListener(OnHomeClicked);
        }
        
        private void OnHomeClicked()
        {
            Close();
            _viewModel.HomeClicked();
        }

        public void OnBackButtonPressed()
        {
            _viewModel.HandleBackButtonPressed();
        }
    }
}