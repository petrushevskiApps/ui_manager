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
        private readonly IUILevelController _uiLevelController;


        public LevelCompletedScreenViewModel(
            INavigationController navigationController,
            IUILevelController uiLevelController)
        {
            NavigationController = navigationController;
            _uiLevelController = uiLevelController;

            StarsAchieved = new ReactiveProperty<int>();
            Title = new ReactiveProperty<string>("Level Completed");
        }

        public void OnBackTriggered()
        {
            NavigationController.ShowScreen<MainScreen>();
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
            NavigationController.ShowScreen<MainScreen>();
        }

        public virtual void SettingsButtonClicked()
        {
            NavigationController.ShowPopup<SettingsPopup>();
        }
    }
}