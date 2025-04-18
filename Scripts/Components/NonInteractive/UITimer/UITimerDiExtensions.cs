using Zenject;

namespace Plugins.UIManager.Scripts.Components.NonInteractive.UITimer
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