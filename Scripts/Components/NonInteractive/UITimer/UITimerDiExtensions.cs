using Zenject;

namespace TwoOneTwoGames.UIManager.Components.NonInteractive
{
    public static class UITimerDiExtensions
    {
        public static void BindTimerFormattingDependencies(this DiContainer container)
        {
            container
                .Bind<ITimerFormattingStrategy>()
                .To<BasicTimerFormattingStrategy>()
                .AsSingle();
        }

        public static void BindTimerColoringDependencies(this DiContainer container)
        {
            container
                .Bind<ITimerColoringStrategy>()
                .To<BasicTimerColoringStrategy>()
                .AsSingle();
        }
    }
}