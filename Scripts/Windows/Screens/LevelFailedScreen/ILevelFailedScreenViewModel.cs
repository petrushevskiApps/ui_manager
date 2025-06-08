namespace TwoOneTwoGames.UIManager.Windows
{
    public interface ILevelFailedScreenViewModel
    {
        void HomeButtonClicked();
        void ReplayButtonClicked();
        void ReviveButtonClicked();
        void SettingsClicked();
        void OnBackTriggered();
        void ScreenShown();
        void ScreenHidden();
        void ScreenClosed();
    }
}