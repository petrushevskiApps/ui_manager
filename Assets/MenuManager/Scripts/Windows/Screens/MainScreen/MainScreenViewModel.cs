namespace slowBulletGames.MemoryValley
{
    public class MainScreenViewModel: IMainScreenViewModel
    {
        // Injected
        protected readonly INavigationController NavigationController;

        public MainScreenViewModel(INavigationController navigationController)
        {
            NavigationController = navigationController;
        }

        public void SettingsClicked()
        {
            NavigationController.ShowPopup<SettingsPopup>();
        }

        public void StartLevelClicked()
        {
            NavigationController.ShowScreen<InGameScreen>();
        }

        public void OnBackTriggered()
        {
            NavigationController.ShowPopup<ExitGamePopup>();
        }
    }
}