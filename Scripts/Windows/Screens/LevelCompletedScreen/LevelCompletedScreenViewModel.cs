using MenuManager.Scripts.Utilitis;
using PetrushevskiApps.UIManager.ScreenNavigation.Navigation;

namespace slowBulletGames.MemoryValley
{
    public class LevelCompletedScreenViewModel : ILevelCompletedScreenViewModel
    {
        // Reactive Properties
        public IReactiveProperty<int> StarsAchieved { get; }
        public IReactiveProperty<string> Title { get; }

        // Injected
        private readonly IScreenNavigation _screenNavigation;
        private readonly IPopupNavigation _popupNavigation;
        private readonly IUILevelController _uiLevelController;


        public LevelCompletedScreenViewModel(
            IScreenNavigation screenNavigation,
            IPopupNavigation popupNavigation,
            IUILevelController uiLevelController)
        {
            _screenNavigation = screenNavigation;
            _popupNavigation = popupNavigation;
            _uiLevelController = uiLevelController;

            StarsAchieved = new ReactiveProperty<int>();
            Title = new ReactiveProperty<string>("Level Completed");
        }

        public void OnBackTriggered()
        {
            _uiLevelController.CollectReward();
            _screenNavigation.ShowMainScreen();
        }

        public virtual void NextLevelButtonClicked()
        {
            _uiLevelController.CollectReward();
            _uiLevelController.StartLevel();
        }

        public virtual void DoubleRewardButtonClicked()
        {
            _uiLevelController.CollectDoubleReward();
            _uiLevelController.StartLevel();
        }

        public virtual void ReplayButtonClicked()
        {
            _uiLevelController.RestartLevel();
        }

        public virtual void HomeButtonClicked()
        {
            _uiLevelController.CollectReward();
            _screenNavigation.ShowMainScreen();
        }

        public virtual void SettingsButtonClicked()
        {
            _popupNavigation.ShowSettingsPopup();
        }
    }
}