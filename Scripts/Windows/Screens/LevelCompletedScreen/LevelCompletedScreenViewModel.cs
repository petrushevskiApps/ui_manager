using MenuManager.Scripts.Utilitis;
using PetrushevskiApps.UIManager.ScreenNavigation.Navigation;

namespace slowBulletGames.MemoryValley
{
    public class LevelCompletedScreenViewModel : ILevelCompletedScreenViewModel
    {
        // Reactive Properties
        public IReactiveProperty<int> EarnedStars { get; private set; }
        public IReactiveProperty<string> Title { get;  private set;}
        public IReactiveProperty<string> EarnedCoinsText { get;  private set;}

        protected int EarnedCoins { get; private set; }

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

            Title = new ReactiveProperty<string>("Level Completed");
            EarnedStars = new ReactiveProperty<int>();
            EarnedCoinsText = new ReactiveProperty<string>();
        }

        public void ScreenResumed()
        {
            EarnedStars = new ReactiveProperty<int>();
            EarnedCoinsText = new ReactiveProperty<string>();
        }

        public void OnBackTriggered()
        {
            _uiLevelController.CollectReward();
            _screenNavigation.ShowMainScreen();
        }

        public virtual void SetEarnedCoins(int coins)
        {
            EarnedCoins = coins;
        }

        public virtual void SetEarnedStars(int earnedStars)
        {
            EarnedStars.Value = earnedStars;
        }

        public virtual void NextLevelButtonClicked()
        {
            _uiLevelController.CollectReward();
            _uiLevelController.StartNextLevel();
        }

        public virtual void DoubleRewardButtonClicked()
        {
            _uiLevelController.CollectDoubleReward();
            _uiLevelController.StartNextLevel();
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