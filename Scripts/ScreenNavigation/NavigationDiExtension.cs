using PetrushevskiApps.UIManager.ScreenNavigation.Navigation;
using Zenject;

namespace PetrushevskiApps.UIManager.ScreenNavigation
{
    public static class NavigationDiExtension
    {
        public static void BindNavigationControllerDependencies(this DiContainer container)
        {
            container
                .Bind<INavigationController>()
                .To<NavigationController>()
                .AsSingle();
            container
                .Bind<IScreenProvider>()
                .WithId("Screen")
                .To<ScreenProvider>()
                .FromComponentInHierarchy()
                .AsSingle();
            container
                .Bind<IScreenProvider>()
                .WithId("PopupScreen")
                .To<PopupScreenProvider>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        public static void BindScreenNavigationDependencies(this DiContainer container)
        {
            container
                .Bind<IScreenNavigation>()
                .To<Navigation.ScreenNavigation>()
                .AsSingle();
        }
        public static void BindPopupNavigationDependencies(this DiContainer container)
        {
            container
                .Bind<IPopupNavigation>()
                .To<PopupNavigation>()
                .AsSingle();
        }
    }
}