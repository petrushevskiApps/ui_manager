using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class NoInternetPopup : UIPopup
    {
        [SerializeField]
        private UIButton _okButton;

        // Injected
        private INoInternetPopupViewModel _viewModel;

        protected override IPopupViewModel GetPopupViewModel()
        {
            return _viewModel;
        }

        [Inject]
        private void Initialize(INoInternetPopupViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Resume()
        {
            base.Resume();
            _okButton.OnClick.AddListener(_viewModel.OkButtonClicked);
        }

        public override void Hide()
        {
            base.Hide();
            _okButton.OnClick.RemoveListener(_viewModel.OkButtonClicked);
        }
    }
}