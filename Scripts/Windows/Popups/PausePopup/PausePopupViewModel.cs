using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class PausePopupViewModel : IPausePopupViewModel
    {
        private readonly INavigationController _navigationController;

        // Injected
        private readonly IPopupNavigation _popupNavigation;
        private readonly IUILevelController _uiLevelController;

        public PausePopupViewModel(
            IPopupNavigation popupNavigation,
            INavigationController navigationController,
            IUILevelController uiLevelController)
        {
            _popupNavigation = popupNavigation;
            _navigationController = navigationController;
            _uiLevelController = uiLevelController;


            Title = new ReactiveProperty<string>("Pause");
            Message = new ReactiveProperty<string>();
        }

        // Reactive Properties
        public IReactiveProperty<string> Title { get; protected set; }
        public IReactiveProperty<string> Message { get; protected set; }

        public virtual void RestartClicked()
        {
            _uiLevelController.RestartLevel();
        }

        public virtual void HomeClicked()
        {
            _popupNavigation.ShowExitLevelPopup();
        }

        public virtual void PlayClicked()
        {
            _navigationController.GoBack();
        }

        public virtual void SettingsClicked()
        {
            _popupNavigation.ShowSettingsPopup();
        }

        public void BackgroundClicked()
        {
            _navigationController.GoBack();
        }
    }
}