using com.petrushevskiapps.menumanager;
using PetrushevskiApps.UIManager;
using slowBulletGames.MemoryValley;
using UnityEngine;
using Zenject;

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

    protected override IPopupViewModel GetPopupViewModel() => _viewModel;
        
    [Inject]
    private void Initialize(ISettingsPopupViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public override void Resume()
    {
        base.Resume();
        _privacySettingsButton.OnClick.AddListener(OnPrivacySettingsClick);
        _privacyPolicyButton.OnClick.AddListener(OnPrivacyPolicyClick);
        _termsOfUseButton.OnClick.AddListener(OnTermsOfUseClick);
        _rateUsButton.OnClick.AddListener(OnRateUsClick);

        _viewModel.AudioToggle.Subscribe(_audioToggle.SetData);
        _viewModel.MusicToggle.Subscribe(_musicToggle.SetData);
        _viewModel.VibrationToggle.Subscribe(_vibrationToggle.SetData);
    }

    public override void Hide()
    {
        base.Hide();
        _privacySettingsButton.OnClick.RemoveListener(OnPrivacySettingsClick);
        _privacyPolicyButton.OnClick.RemoveListener(OnPrivacyPolicyClick);
        _termsOfUseButton.OnClick.RemoveListener(OnTermsOfUseClick);
        _rateUsButton.OnClick.RemoveListener(OnRateUsClick);
        
        _viewModel.AudioToggle.Unsubscribe(_audioToggle.SetData);
        _viewModel.MusicToggle.Unsubscribe(_musicToggle.SetData);
        _viewModel.VibrationToggle.Unsubscribe(_vibrationToggle.SetData);
    }

    private void OnRateUsClick()
    {
        _viewModel.RateUsClicked();
    }

    private void OnTermsOfUseClick()
    {
        _viewModel.TermsOfUseClicked();
    }

    private void OnPrivacyPolicyClick()
    {
        _viewModel.PrivacyPolicyClicked();
    }

    private void OnPrivacySettingsClick()
    {
        _viewModel.PrivacySettingsClicked();
    }
}

