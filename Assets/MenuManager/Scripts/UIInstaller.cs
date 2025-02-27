using PetrushevskiApps.UIManager.ScreenNavigation;
using Zenject;

public class UIInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        ScreenNavigationDiExtension.BindDependencies(Container);
        WindowsDiExtension.BindPausePopupDependencies(Container);
        WindowsDiExtension.BindSettingsPopupDependencies(Container);
        WindowsDiExtension.BindNoInternetPopupDependencies(Container);
    }
}