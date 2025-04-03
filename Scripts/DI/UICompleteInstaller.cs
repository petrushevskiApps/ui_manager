using MenuManager.Scripts.Components.NonInteractive;
using PetrushevskiApps.UIManager.ScreenNavigation;
using Zenject;

public class UICompleteInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindScreenNavigationDependencies();
        Container.BindPopupDependencies();
        Container.BindNonInteractiveComponentDependencies();
        
        // Screen Bindings
        Container.BindMainScreenDependencies();
        Container.BindInGameScreenDependencies();
        Container.BindLevelFailedScreenDependencies();
        Container.BindLevelCompletedScreenDependencies();
    }
}