using MenuManager.Scripts.Utilitis;
using UnityEngine;

public class SettingsPopupViewModel : ISettingsPopupViewModel
{
    // Reactive Properties
    public IReactiveProperty<string> Title { get; protected set; }
    public IReactiveProperty<string> Message { get; protected set; }

    public IReadOnlyReactiveProperty<bool> AudioToggle => _audioToggle;
    public IReadOnlyReactiveProperty<bool> MusicToggle => _musicToggle;
    public IReadOnlyReactiveProperty<bool> VibrationToggle => _vibrationToggle;

    // Injected
    private readonly IUrlConfigurationProvider _urlConfigurationProvider;
    private readonly INavigationController _navigationController;

    // Internal
    private readonly IReactiveProperty<bool> _audioToggle;
    private readonly IReactiveProperty<bool> _musicToggle;
    private readonly IReactiveProperty<bool> _vibrationToggle;


    public SettingsPopupViewModel(
        IUrlConfigurationProvider urlConfigurationProvider,
        INavigationController navigationController)
    {
        _urlConfigurationProvider = urlConfigurationProvider;
        _navigationController = navigationController;
        _audioToggle = new ReactiveProperty<bool>(false);
        _musicToggle = new ReactiveProperty<bool>(false);
        _vibrationToggle = new ReactiveProperty<bool>(false);
        
        Title = new ReactiveProperty<string>("Settings");
        Message = new ReactiveProperty<string>(null);
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

    public virtual void AudioToggleClicked()
    {
        _audioToggle.Value = !_audioToggle.Value;
        //PlayerDataController.AudioToggle = !PlayerDataController.AudioToggle;
        //audioToggle.ToggleStatus = PlayerDataController.AudioToggle;
    }

    public virtual void MusicToggleClicked()
    {
        _musicToggle.Value = !_musicToggle.Value;
        //PlayerDataController.MusicToggle = !PlayerDataController.MusicToggle;
        //musicToggle.ToggleStatus = PlayerDataController.MusicToggle;
    }

    public virtual void VibrationToggleClicked()
    {
        _vibrationToggle.Value = !_vibrationToggle.Value;
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