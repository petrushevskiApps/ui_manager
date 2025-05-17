using PetrushevskiApps.UIManager.ScreenNavigation;
using Zenject;

public class UIScreenBindingsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindMainScreenDependencies();
        Container.BindInGameScreenDependencies();
        Container.BindLevelFailedScreenDependencies();
        Container.BindLevelCompletedScreenDependencies();
        Container.BindLevelsScreenDependencies();
    }
}