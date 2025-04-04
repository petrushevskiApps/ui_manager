using slowBulletGames.MemoryValley;

namespace PetrushevskiApps.UIManager.ScreenNavigation.Navigation
{
    public class PopupNavigation: IPopupNavigation
    {
        private readonly INavigationController _navigationController;

        public PopupNavigation(INavigationController navigationController)
        {
            _navigationController = navigationController;
        }

        public void ShowNoInternetPopup()
        {
            _navigationController.ShowPopup<NoInternetPopup>();
        }

        public void ShowPausePopup()
        {
            _navigationController.ShowPopup<PausePopup>();
        }

        public void ShowExitLevelPopup()
        {
            _navigationController.ShowPopup<ExitLevelPopup>();
        }

        public void ShowSettingsPopup()
        {
            _navigationController.ShowPopup<SettingsPopup>();
        }

        public void ShowExitGamePopup()
        {
            _navigationController.ShowPopup<ExitGamePopup>();
        }
    }
}