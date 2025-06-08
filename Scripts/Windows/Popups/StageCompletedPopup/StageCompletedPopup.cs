using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Windows
{
    /// <summary>
    ///     Stage Completed Popup is shown when Stage is completed.
    ///     Stage is a group of levels, for example Stage is Lava World
    ///     and all levels set in the Lava World are in this group / stage.
    /// </summary>
    public class StageCompletedPopup : UIPopup
    {
        [SerializeField]
        private UIButton _homeButton;

        // Injected
        private IStageCompletedPopupViewModel _viewModel;

        protected override IPopupViewModel GetPopupViewModel()
        {
            return _viewModel;
        }

        [Inject]
        private void Initialize(IStageCompletedPopupViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Resume()
        {
            base.Resume();
            _homeButton.OnClick.AddListener(OnHomeClicked);
        }

        public override void Hide()
        {
            base.Hide();
            _homeButton.OnClick.RemoveAllListeners();
        }

        private void OnHomeClicked()
        {
            Close();
            _viewModel.HomeClicked();
        }
    }
}