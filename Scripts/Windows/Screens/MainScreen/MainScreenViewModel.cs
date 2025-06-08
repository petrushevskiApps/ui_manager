using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.ScreenNavigation;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class MainScreenViewModel : IMainScreenViewModel
    {
        // Injected
        private readonly IPopupNavigation _popupNavigation;
        private readonly IUILevelController _uiLevelController;

        public MainScreenViewModel(
            IPopupNavigation popupNavigation,
            IUILevelController uiLevelController)
        {
            _popupNavigation = popupNavigation;
            _uiLevelController = uiLevelController;
        }

        public virtual void SettingsClicked()
        {
            _popupNavigation.ShowSettingsPopup();
        }

        public virtual void StartLevelClicked()
        {
            _uiLevelController.StartLevel();
        }

        public virtual void OnBackTriggered()
        {
            _popupNavigation.ShowExitGamePopup();
        }
    }
}