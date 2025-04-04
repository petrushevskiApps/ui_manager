using MenuManager.Scripts.Components.NonInteractive;
using PetrushevskiApps.UIManager.ScreenNavigation;
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
        
        // Screen Bindings
        Container.BindMainScreenDependencies();
        Container.BindInGameScreenDependencies();
        Container.BindLevelFailedScreenDependencies();
        Container.BindLevelCompletedScreenDependencies();
    }
}