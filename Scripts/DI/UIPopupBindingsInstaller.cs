using PetrushevskiApps.UIManager.ScreenNavigation;
using Zenject;

public class UIPopupBindingsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindPopupDependencies();
    }
}