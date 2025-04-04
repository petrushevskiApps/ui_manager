using MenuManager.Scripts.Utilitis;
using PetrushevskiApps.UIManager.ScreenNavigation.Navigation;
using UnityEngine;

namespace slowBulletGames.MemoryValley
{
    public class PausePopupViewModel : IPausePopupViewModel
    {
        // Reactive Properties
        public IReactiveProperty<string> Title { get; protected set; }
        public IReactiveProperty<string> Message { get; protected set;}

        // Injected
        private readonly IPopupNavigation _popupNavigation;
        private readonly INavigationController _navigationController;
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
            Message = new ReactiveProperty<string>(null);
        }

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