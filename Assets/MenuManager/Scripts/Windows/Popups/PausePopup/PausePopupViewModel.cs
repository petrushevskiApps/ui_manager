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

        public PausePopupViewModel(
            INavigationController navigationController)
        {
            _navigationController = navigationController;

            
            Title = new ReactiveProperty<string>("Pause");
            Message = new ReactiveProperty<string>(null);
        }

        public virtual void RestartClicked()
        {
            Debug.LogWarning("Restart clicked method is not implemented.");
        }

        public virtual void HomeClicked()
        {
            _navigationController.ShowPopup<LevelLeavePopup>();
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