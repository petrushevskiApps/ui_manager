using PetrushevskiApps.UIManager.ScreenNavigation.Navigation;

namespace slowBulletGames.MemoryValley
{
    public class LevelFailedScreenViewModel : ILevelFailedScreenViewModel
    {
        // Injected
        private readonly IScreenNavigation _screenNavigation;
        private readonly IPopupNavigation _popupNavigation;
        private readonly IUILevelController _uiLevelController;

        public LevelFailedScreenViewModel(
            IScreenNavigation screenNavigation,
            IPopupNavigation popupNavigation,
            IUILevelController uiLevelController)
        {
            _screenNavigation = screenNavigation;
            _popupNavigation = popupNavigation;
            _uiLevelController = uiLevelController;
        }
        
        public virtual void OnBackTriggered()
        {
            _screenNavigation.ShowMainScreen();
        }

        public virtual void HomeButtonClicked()
        {
            _screenNavigation.ShowMainScreen();
        }

        public virtual void ReplayButtonClicked()
        {
            _uiLevelController.RestartLevel();
        }

        public virtual void ReviveButtonClicked()
        {
            _uiLevelController.ReviveAndContinueLevel();
        }

        public void SettingsClicked()
        {
            _popupNavigation.ShowSettingsPopup();
        }
    }
}