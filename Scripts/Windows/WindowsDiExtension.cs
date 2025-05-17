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
        public static void BindLevelFailedScreenDependencies(this DiContainer container)
        {
            container
                .Bind<ILevelFailedScreenViewModel>()
                .To<LevelFailedScreenViewModel>()
                .AsSingle();
        }
        public static void BindLevelCompletedScreenDependencies(this DiContainer container)
        {
            container
                .Bind<ILevelCompletedScreenViewModel>()
                .To<LevelCompletedScreenViewModel>()
                .AsSingle();
        }
        public static void BindLevelsScreenDependencies(this DiContainer container)
        {
            container
                .Bind<ILevelsScreenViewModel>()
                .To<LevelsScreenViewModel>()
                .AsSingle();
        }
        public static void BindPopupDependencies(this DiContainer container)
        {
            container
                .Bind<INoInternetPopupViewModel>()
                .To<NoInternetPopupViewModel>()
                .AsSingle();
            container
                .Bind<IPausePopupViewModel>()
                .To<PausePopupViewModel>()
                .AsSingle();
            container
                .Bind<ISettingsPopupViewModel>()
                .To<SettingsPopupViewModel>()
                .AsSingle();
            container
                .Bind<IExitLevelPopupViewModel>()
                .To<ExitLevelPopupViewModel>()
                .AsSingle();
            container
                .Bind<IExitGamePopupViewModel>()
                .To<ExitGamePopupViewModel>()
                .AsSingle();
        }
    }
}