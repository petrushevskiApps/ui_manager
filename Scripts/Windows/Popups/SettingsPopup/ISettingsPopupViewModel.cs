using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    public interface ISettingsPopupViewModel : IPopupViewModel
    {
        IReadOnlyReactiveProperty<ToggleViewData> AudioToggle { get; }
        IReadOnlyReactiveProperty<ToggleViewData> MusicToggle { get; }
        IReadOnlyReactiveProperty<ToggleViewData> VibrationToggle { get; }
        IReactiveProperty<UIButtonViewData> PrivacyPolicyButton { get; }
        IReactiveProperty<UIButtonViewData> PrivacySettingsButton { get; }
        IReactiveProperty<UIButtonViewData> TermsOfUseButton { get; }
        IReactiveProperty<UIButtonViewData> RateUsButton { get; }
        void RateUsClicked();
        void TermsOfUseClicked();
        void PrivacyPolicyClicked();
        void PrivacySettingsClicked();
    }
}