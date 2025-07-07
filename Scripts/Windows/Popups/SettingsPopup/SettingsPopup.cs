using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class SettingsPopup : UIPopup
    {
        [Header("Toggles")]
        [SerializeField]
        private UIToggle _audioToggle;

        [SerializeField]
        private UIToggle _musicToggle;

        [SerializeField]
        private UIToggle _vibrationToggle;

        [SerializeField]
        private UIButton _rateUsButton;

        [Header("Privacy Settings")]
        [SerializeField]
        private UIButton _privacySettingsButton;

        [SerializeField]
        private UIButton _privacyPolicyButton;

        [SerializeField]
        private UIButton _termsOfUseButton;

        // Injected
        private ISettingsPopupViewModel _viewModel;

        protected override IPopupViewModel GetPopupViewModel()
        {
            return _viewModel;
        }

        [Inject]
        private void Initialize(ISettingsPopupViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Resume()
        {
            base.Resume();
            
            _viewModel.PrivacySettingsButton.Subscribe(_privacySettingsButton.SetData);
            _viewModel.PrivacyPolicyButton.Subscribe(_privacyPolicyButton.SetData);
            _viewModel.TermsOfUseButton.Subscribe(_termsOfUseButton.SetData);
            _viewModel.RateUsButton.Subscribe(_rateUsButton.SetData);

            _viewModel.AudioToggle.Subscribe(_audioToggle.SetData);
            _viewModel.MusicToggle.Subscribe(_musicToggle.SetData);
            _viewModel.VibrationToggle.Subscribe(_vibrationToggle.SetData);
        }

        public override void Hide()
        {
            base.Hide();
            
            _viewModel.PrivacySettingsButton.Unsubscribe(_privacySettingsButton.SetData);
            _viewModel.PrivacyPolicyButton.Unsubscribe(_privacyPolicyButton.SetData);
            _viewModel.TermsOfUseButton.Unsubscribe(_termsOfUseButton.SetData);
            _viewModel.RateUsButton.Unsubscribe(_rateUsButton.SetData);

            _viewModel.AudioToggle.Unsubscribe(_audioToggle.SetData);
            _viewModel.MusicToggle.Unsubscribe(_musicToggle.SetData);
            _viewModel.VibrationToggle.Unsubscribe(_vibrationToggle.SetData);
        }
    }
}