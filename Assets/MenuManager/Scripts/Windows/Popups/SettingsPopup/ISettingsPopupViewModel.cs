using MenuManager.Scripts.Utilitis;
using slowBulletGames.MemoryValley;

public interface ISettingsPopupViewModel : IPopupViewModel
{
    void RateUsClicked();
    void TermsOfUseClicked();
    void PrivacyPolicyClicked();
    void PrivacySettingsClicked();
    void AudioToggleClicked();
    void MusicToggleClicked();
    IReadOnlyReactiveProperty<bool> AudioToggle { get; }
    IReadOnlyReactiveProperty<bool> MusicToggle { get; }
    IReadOnlyReactiveProperty<bool> VibrationToggle { get; }
    void VibrationToggleClicked();
}