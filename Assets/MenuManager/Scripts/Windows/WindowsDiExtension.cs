using slowBulletGames.MemoryValley;
using Zenject;

namespace PetrushevskiApps.UIManager.ScreenNavigation
{
    public static class WindowsDiExtension
    {
        public static void BindNoInternetPopupDependencies(DiContainer container)
        {
            container
                .Bind<INoInternetPopupViewModel>()
                .To<NoInternetPopupViewModel>()
                .AsSingle();
        }
        public static void BindPausePopupDependencies(DiContainer container)
        {
            container
                .Bind<IPausePopupViewModel>()
                .To<PausePopupViewModel>()
                .AsSingle();
        }
        public static void BindSettingsPopupDependencies(DiContainer container)
        {
            container
                .Bind<ISettingsPopupViewModel>()
                .To<SettingsPopupViewModel>()
                .AsSingle();
        }
    }
}