namespace PetrushevskiApps.UIManager.ScreenNavigation.Navigation
{
    public interface IPopupNavigation
    {
        public void ShowNoInternetPopup();
        public void ShowPausePopup();
        public void ShowExitLevelPopup();
        public void ShowSettingsPopup();
        public void ShowExitGamePopup();
    }
}