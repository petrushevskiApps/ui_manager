using slowBulletGames.MemoryValley;
using Zenject;

namespace PetrushevskiApps.UIManager.ScreenNavigation
{
    public static class WindowsDiExtension
    {
        public static void BindMainScreenDependencies(this DiContainer container)
        {
            container
                .Bind<IMainScreenViewModel>()
                .To<MainScreenViewModel>()
                .AsSingle();
        }
        public static void BindInGameScreenDependencies(this DiContainer container)
        {
            container
                .Bind<IInGameScreenViewModel>()
                .To<InGameScreenViewModel>()
                .AsSingle();
        }
        public static void BindNoInternetPopupDependencies(this DiContainer container)
        {
            container
                .Bind<INoInternetPopupViewModel>()
                .To<NoInternetPopupViewModel>()
                .AsSingle();
        }
        public static void BindPausePopupDependencies(this DiContainer container)
        {
            container
                .Bind<IPausePopupViewModel>()
                .To<PausePopupViewModel>()
                .AsSingle();
        }
        public static void BindSettingsPopupDependencies(this DiContainer container)
        {
            container
                .Bind<ISettingsPopupViewModel>()
                .To<SettingsPopupViewModel>()
                .AsSingle();
        }
    }
}