using MenuManager.Scripts.Components.NonInteractive;
using MenuManager.Scripts.Utilitis;
using PetrushevskiApps.UIManager.ScreenNavigation.Navigation;

namespace slowBulletGames.MemoryValley
{
    public class InGameScreenViewModel : IInGameScreenViewModel
    {
        public IReactiveProperty<string> LevelTitle { get; protected set; }
        public IReactiveProperty<UIProgressBarData> ProgressBarData { get; protected set;}
        
        // Injected
        private readonly IPopupNavigation _popupNavigation;

        public InGameScreenViewModel(IPopupNavigation popupNavigation)
        {
            _popupNavigation = popupNavigation;
            LevelTitle = new ReactiveProperty<string>("");
            ProgressBarData = new ReactiveProperty<UIProgressBarData>();
        }
        
        public virtual void PauseClicked()
        {
            _popupNavigation.ShowPausePopup();
        }

        public void OnBackTriggered()
        {
            _popupNavigation.ShowExitLevelPopup();
        }
    }
}