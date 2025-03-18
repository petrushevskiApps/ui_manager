using slowBulletGames.MemoryValley;
using Zenject;

namespace PetrushevskiApps.UIManager.ScreenNavigation
{
    public static class WindowsDiExtension
    {
        public static void BindScreensDependencies(this DiContainer container)
        {
            container
                .Bind<IMainScreenViewModel>()
                .To<MainScreenViewModel>()
                .AsSingle();
            container
                .Bind<IInGameScreenViewModel>()
                .To<InGameScreenViewModel>()
                .AsSingle();
            container
                .Bind<ILevelFailedScreenViewModel>()
                .To<LevelFailedScreenViewModel>()
                .AsSingle();
            container
                .Bind<ILevelCompletedScreenViewModel>()
                .To<LevelCompletedScreenViewModel>()
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