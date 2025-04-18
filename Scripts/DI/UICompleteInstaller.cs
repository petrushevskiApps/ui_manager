using MenuManager.Scripts.Components.NonInteractive;
using PetrushevskiApps.UIManager.ScreenNavigation;
using Plugins.UIManager.Scripts.Components.NonInteractive.UITimer;
using Zenject;

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
        
        // Screen Bindings
        Container.BindMainScreenDependencies();
        Container.BindInGameScreenDependencies();
        Container.BindLevelFailedScreenDependencies();
        Container.BindLevelCompletedScreenDependencies();
    }
}