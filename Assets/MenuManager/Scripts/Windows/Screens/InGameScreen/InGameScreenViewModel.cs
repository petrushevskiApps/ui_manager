using MenuManager.Scripts.Components.NonInteractive;
using MenuManager.Scripts.Utilitis;

namespace slowBulletGames.MemoryValley
{
    public class InGameScreenViewModel : IInGameScreenViewModel
    {
        public IReactiveProperty<string> LevelTitle { get; protected set; }
        public IReactiveProperty<UIProgressBarData> ProgressBarData { get; protected set;}
        
        // Injected
        protected readonly INavigationController NavigationController;

        public InGameScreenViewModel(INavigationController navigationController)
        {
            NavigationController = navigationController;
            LevelTitle = new ReactiveProperty<string>("");
            ProgressBarData = new ReactiveProperty<UIProgressBarData>();
        }
        
        public virtual void PauseClicked()
        {
            NavigationController.ShowPopup<PausePopup>();
        }

        public virtual void OnBackTriggered()
        {
            NavigationController.ShowPopup<ExitLevelPopup>();
        }
    }
}