using MenuManager.Scripts.Utilitis;
using UnityEngine;

namespace slowBulletGames.MemoryValley
{
    public class PausePopupViewModel : IPausePopupViewModel
    {
        // Reactive Properties
        public IReactiveProperty<string> Title { get; protected set; }
        public IReactiveProperty<string> Message { get; protected set;}

        // Injected
        private readonly INavigationController _navigationController;
        private readonly IUILevelController _uiLevelController;

        public PausePopupViewModel(
            INavigationController navigationController,
            IUILevelController uiLevelController)
        {
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
            _navigationController.ShowPopup<ExitLevelPopup>();
        }

        public virtual void PlayClicked()
        {
            _navigationController.GoBack();
        }

        public virtual void SettingsClicked()
        {
            _navigationController.ShowPopup<SettingsPopup>();
        }

        public void BackgroundClicked()
        {
            _navigationController.GoBack();
        }
    }
}