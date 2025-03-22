using PetrushevskiApps.UIManager.ScreenNavigation;
using Zenject;

public class UICompleteInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindScreenNavigationDependencies();
        Container.BindPopupDependencies();
        
        // Screen Bindings
        Container.BindMainScreenDependencies();
        Container.BindInGameScreenDependencies();
        Container.BindLevelFailedScreenDependencies();
        Container.BindLevelCompletedScreenDependencies();
    }
}