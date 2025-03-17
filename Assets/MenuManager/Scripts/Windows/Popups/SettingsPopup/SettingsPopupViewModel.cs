using com.petrushevskiapps.menumanager;
using MenuManager.Scripts.Utilitis;
using UnityEngine;

public class SettingsPopupViewModel : ISettingsPopupViewModel
{
    // Reactive Properties
    public IReactiveProperty<string> Title { get; protected set; }
    public IReactiveProperty<string> Message { get; protected set; }

    public IReadOnlyReactiveProperty<ToggleViewData> AudioToggle => _audioToggle;
    public IReadOnlyReactiveProperty<ToggleViewData> MusicToggle => _musicToggle;
    public IReadOnlyReactiveProperty<ToggleViewData> VibrationToggle => _vibrationToggle;

    // Injected
    private readonly IUrlConfigurationProvider _urlConfigurationProvider;
    private readonly INavigationController _navigationController;
    private readonly ISettingsStateProvider _settingsStateProvider;
    private readonly ISettingsStateUpdater _settingsStateUpdater;

    // Internal
    private readonly IReactiveProperty<ToggleViewData> _audioToggle;
    private readonly IReactiveProperty<ToggleViewData> _musicToggle;
    private readonly IReactiveProperty<ToggleViewData> _vibrationToggle;


    public SettingsPopupViewModel(
        IUrlConfigurationProvider urlConfigurationProvider,
        INavigationController navigationController,
        ISettingsStateProvider settingsStateProvider,
        ISettingsStateUpdater settingsStateUpdater)
    {
        _urlConfigurationProvider = urlConfigurationProvider;
        _navigationController = navigationController;
        _settingsStateProvider = settingsStateProvider;
        _settingsStateUpdater = settingsStateUpdater;

        _audioToggle = new ReactiveProperty<ToggleViewData>();
        _musicToggle = new ReactiveProperty<ToggleViewData>();
        _vibrationToggle = new ReactiveProperty<ToggleViewData>();
        SetToggles();
        
        Title = new ReactiveProperty<string>("Settings");
        Message = new ReactiveProperty<string>("Thank you for playing our game.");
    }

    private void SetToggles()
    {
        _audioToggle.Value = new ToggleViewData()
        {
            Label = "Sound Effects",
            State = _settingsStateProvider.IsSoundEffectsActive,
            OnToggleStateChanged = AudioToggleClicked,
            IsActive = true
        };
        _musicToggle.Value = new ToggleViewData()
        {
            Label = "Game Music",
            State = _settingsStateProvider.IsMusicActive,
            OnToggleStateChanged = MusicToggleClicked,
            IsActive = true
        };
        _vibrationToggle.Value = new ToggleViewData()
        {
            Label = "Vibrations",
            State = _settingsStateProvider.IsVibrationsActive,
            OnToggleStateChanged = VibrationToggleClicked,
            IsActive = true
        };
    }
    public virtual  void RateUsClicked()
    {
        throw new System.NotImplementedException();
    }

    public virtual void TermsOfUseClicked()
    {
        OpenURL(_urlConfigurationProvider.TermsOfUseUrl);
    }

    public virtual void PrivacyPolicyClicked()
    {
        OpenURL(_urlConfigurationProvider.PrivacyPolicyUrl);
    }

    public virtual void PrivacySettingsClicked()
    {
        OpenURL(_urlConfigurationProvider.PrivacySettingsUrl);
    }

    protected virtual void AudioToggleClicked()
    {
        bool newState = !_audioToggle.Value.State;
        _audioToggle.Value = _audioToggle.Value with
        {
            State = newState
        };
        _settingsStateUpdater.UpdateSoundEffectsState(newState);
    }

    protected virtual void MusicToggleClicked()
    {
        bool newState = !_musicToggle.Value.State;
        _musicToggle.Value = _musicToggle.Value with
        {
            State = newState
        };
        _settingsStateUpdater.UpdateGameMusicState(newState);
    }

    protected virtual void VibrationToggleClicked()
    {
        bool newState = !_vibrationToggle.Value.State;
        _vibrationToggle.Value = _vibrationToggle.Value with
        {
            State = newState
        };
        _settingsStateUpdater.UpdateVibrationsState(newState);
    }

    private void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
    
    public void BackgroundClicked()
    {
        _navigationController.GoBack();
    }
}