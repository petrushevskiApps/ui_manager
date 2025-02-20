using PetrushevskiApps.UIManager.ScreenNavigation;
using Zenject;

public class MainInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        ScreenNavigationDiExtension.BindDependencies(Container);
    }
}