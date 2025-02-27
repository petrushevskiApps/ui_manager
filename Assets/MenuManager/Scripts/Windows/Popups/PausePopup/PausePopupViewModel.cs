using UnityEngine;

namespace slowBulletGames.MemoryValley
{
    public class PausePopupViewModel : IPausePopupViewModel
    {
        public string Title { get; protected set; }

        public string Message { get; protected set;}

        // Injected
        private readonly INavigationController _navigationController;

        public PausePopupViewModel(
            INavigationController navigationController)
        {
            _navigationController = navigationController;

            Title = "Pause";
            Message = "";
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
    }
}