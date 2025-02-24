using Zenject;

namespace PetrushevskiApps.UIManager.ScreenNavigation
{
    public static class ScreenNavigationDiExtension
    {
        public static void BindDependencies(DiContainer container)
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
    }
}