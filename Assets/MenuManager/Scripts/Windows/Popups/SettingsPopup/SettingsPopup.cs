using com.petrushevskiapps.menumanager;
using PetrushevskiApps.UIManager;
using slowBulletGames.MemoryValley;
using UnityEngine;
using Zenject;

public class SettingsPopup : UIPopup
{
    [Header("Toggle Buttons")]
    [SerializeField]
    private GameObject _audioButtonObject;
    [SerializeField]
    private GameObject _musicToggleObject;
    [SerializeField]
    private GameObject _vibrationToggleObject;
    [SerializeField]
    private UIButton _rateUsButton;

    [Header("Privacy Settings")]
    [SerializeField]
    private UIButton _privacySettingsButton;
    [SerializeField]
    private UIButton _privacyPolicyButton;
    [SerializeField]
    private UIButton _termsOfUseButton;

    private UIButton _audioButton;
    private UIButton _musicButton;
    private UIButton _vibrationButton;

    private UIToggle _audioToggle;
    private UIToggle _musicToggle;
    private UIToggle _vibrationToggle;

    // Injected
    private ISettingsPopupViewModel _viewModel;

    protected override IPopupViewModel GetPopupViewModel() => _viewModel;
        
    [Inject]
    private void Initialize(ISettingsPopupViewModel viewModel)
    {
        _viewModel = viewModel;
    }
    
    private void Awake()
    {
        _audioButton = _audioButtonObject.GetComponent<UIButton>();
        _audioToggle = _audioButtonObject.GetComponent<UIToggle>();

        _musicButton = _musicToggleObject.GetComponent<UIButton>();
        _musicToggle = _musicToggleObject.GetComponent<UIToggle>();
        
        _vibrationButton = _vibrationToggleObject.GetComponent<UIButton>();
        _vibrationToggle = _vibrationToggleObject.GetComponent<UIToggle>();
    }

    private void OnEnable()
    {
        _audioButton.onClick.AddListener(OnAudioToggleClick);
        _musicButton.onClick.AddListener(OnMusicToggleClick);
        _vibrationButton.onClick.AddListener(OnVibrationToggleClicked);
        
        _privacySettingsButton.onClick.AddListener(OnPrivacySettingsClick);
        _privacyPolicyButton.onClick.AddListener(OnPrivacyPolicyClick);
        _termsOfUseButton.onClick.AddListener(OnTermsOfUseClick);
        _rateUsButton.onClick.AddListener(OnRateUsClick);

        _viewModel.AudioToggle.Subscribe(OnAudioToggleUpdated);
        _viewModel.MusicToggle.Subscribe(OnMusicToggleUpdated);
        _viewModel.VibrationToggle.Subscribe(OnVibrationToggleUpdated);
    }

    private void OnDisable()
    {
        _audioButton.onClick.RemoveListener(OnAudioToggleClick);
        _musicButton.onClick.RemoveListener(OnMusicToggleClick);
        _privacySettingsButton.onClick.RemoveListener(OnPrivacySettingsClick);
        _privacyPolicyButton.onClick.RemoveListener(OnPrivacyPolicyClick);
        _termsOfUseButton.onClick.RemoveListener(OnTermsOfUseClick);
        _rateUsButton.onClick.RemoveListener(OnRateUsClick);
        
        _viewModel.AudioToggle.Unsubscribe(OnAudioToggleUpdated);
        _viewModel.MusicToggle.Unsubscribe(OnMusicToggleUpdated);
        _viewModel.VibrationToggle.Unsubscribe(OnVibrationToggleUpdated);
    }

    private void OnAudioToggleUpdated(bool audioToggleState)
    {
        _audioToggle.IsOn = audioToggleState;
    }

    private void OnMusicToggleUpdated(bool musicToggleState)
    {
        _musicToggle.IsOn = musicToggleState;
    }

    private void OnVibrationToggleUpdated(bool vibrationToggleState)
    {
        _vibrationToggle.IsOn = vibrationToggleState;
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

    private void OnMusicToggleClick()
    {
        _viewModel.MusicToggleClicked();
    }

    private void OnAudioToggleClick()
    {
        _viewModel.AudioToggleClicked();
    }

    private void OnVibrationToggleClicked()
    {
        _viewModel.VibrationToggleClicked();
    }
}

