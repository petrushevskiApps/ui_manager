using PetrushevskiApps.UIManager.ScreenNavigation;
using Zenject;

public class UIInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindScreenNavigationDependencies();
        Container.BindPausePopupDependencies();
        Container.BindSettingsPopupDependencies();
        Container.BindNoInternetPopupDependencies();
        Container.BindMainScreenDependencies();
        Container.BindInGameScreenDependencies();
    }
}