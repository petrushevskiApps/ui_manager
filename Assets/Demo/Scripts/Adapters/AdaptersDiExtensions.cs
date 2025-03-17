using slowBulletGames.MemoryValley;
using Zenject;

namespace MenuManager.Scripts.Adapters
{
    public static class AdaptersDiExtensions
    {
        public static void BindUiSoundSystemDependencies(this DiContainer container)
        {
            container
                .Bind<ISoundSystem>()
                .To<UISoundSystem>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
        public static void BindNetworkSystemDependencies(this DiContainer container)
        {
            container
                .Bind<IConnectionListener>()
                .To<ConnectionListenerDummyAdapter>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
        public static void BindLevelControllerDependencies(this DiContainer container)
        {
            container
                .Bind<IUILevelControlled>()
                .To<LevelController>()
                .AsSingle();
        }
        public static void BindSettingsStateControllerDependencies(this DiContainer container)
        {
            container
                .Bind(typeof(ISettingsStateProvider),
                    typeof(ISettingsStateUpdater))
                .To<SettingsStateController>()
                .AsSingle();
        }
    }
}