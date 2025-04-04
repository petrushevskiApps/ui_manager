using PetrushevskiApps.UIManager.ScreenNavigation;
using Zenject;

public class UINavigationInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindNavigationControllerDependencies();
    }
}