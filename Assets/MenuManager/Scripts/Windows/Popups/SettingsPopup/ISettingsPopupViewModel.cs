using com.petrushevskiapps.menumanager;
using MenuManager.Scripts.Utilitis;
using slowBulletGames.MemoryValley;

public interface ISettingsPopupViewModel : IPopupViewModel
{
    void RateUsClicked();
    void TermsOfUseClicked();
    void PrivacyPolicyClicked();
    void PrivacySettingsClicked();
    IReadOnlyReactiveProperty<ToggleViewData> AudioToggle { get; }
    IReadOnlyReactiveProperty<ToggleViewData> MusicToggle { get; }
    IReadOnlyReactiveProperty<ToggleViewData> VibrationToggle { get; }
}