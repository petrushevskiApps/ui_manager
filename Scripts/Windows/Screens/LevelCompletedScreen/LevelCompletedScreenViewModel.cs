using MenuManager.Scripts.Utilitis;

namespace slowBulletGames.MemoryValley
{
    public class LevelCompletedScreenViewModel : ILevelCompletedScreenViewModel
    {
        // Reactive Properties
        public IReactiveProperty<int> StarsAchieved { get; }
        public IReactiveProperty<string> Title { get; }

        // Injected
        protected readonly INavigationController NavigationController;
        private readonly IUILevelControlled _uiLevelControlled;


        public LevelCompletedScreenViewModel(
            INavigationController navigationController,
            IUILevelControlled uiLevelControlled)
        {
            NavigationController = navigationController;
            _uiLevelControlled = uiLevelControlled;

            StarsAchieved = new ReactiveProperty<int>();
            Title = new ReactiveProperty<string>("Level Completed");
        }

        public void OnBackTriggered()
        {
            NavigationController.ShowScreen<MainScreen>();
        }

        public virtual void NextLevelButtonClicked()
        {
            _uiLevelControlled.CollectReward();
            _uiLevelControlled.StartNextLevel();
        }

        public virtual void DoubleRewardButtonClicked()
        {
            _uiLevelControlled.CollectDoubleReward();
            _uiLevelControlled.StartNextLevel();
        }

        public virtual void ReplayButtonClicked()
        {
            _uiLevelControlled.RestartLevel();
        }

        public virtual void HomeButtonClicked()
        {
            NavigationController.ShowScreen<MainScreen>();
        }

        public virtual void SettingsButtonClicked()
        {
            NavigationController.ShowPopup<SettingsPopup>();
        }
    }
}