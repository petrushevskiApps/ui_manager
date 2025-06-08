using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    public interface ISettingsPopupViewModel : IPopupViewModel
    {
        IReadOnlyReactiveProperty<ToggleViewData> AudioToggle { get; }
        IReadOnlyReactiveProperty<ToggleViewData> MusicToggle { get; }
        IReadOnlyReactiveProperty<ToggleViewData> VibrationToggle { get; }
        void RateUsClicked();
        void TermsOfUseClicked();
        void PrivacyPolicyClicked();
        void PrivacySettingsClicked();
    }
}