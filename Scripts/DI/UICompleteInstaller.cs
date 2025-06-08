using TwoOneTwoGames.UIManager.Components.NonInteractive;
using TwoOneTwoGames.UIManager.InfiniteScrollList;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using TwoOneTwoGames.UIManager.Windows;
using Zenject;

namespace TwoOneTwoGames.UIManager.Di
{
    public class UICompleteInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindNavigationControllerDependencies();
            Container.BindScreenNavigationDependencies();
            Container.BindPopupNavigationDependencies();
            Container.BindPopupDependencies();
            Container.BindNonInteractiveComponentDependencies();
            Container.BindTimerColoringDependencies();
            Container.BindTimerFormattingDependencies();
            Container.BindInfiniteScrollListDependencies();

            // Screen Bindings
            Container.BindMainScreenDependencies();
            Container.BindInGameScreenDependencies();
            Container.BindLevelFailedScreenDependencies();
            Container.BindLevelCompletedScreenDependencies();
            Container.BindLevelsScreenDependencies();
        }
    }
}