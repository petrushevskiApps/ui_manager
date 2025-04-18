using MenuManager.Scripts.Components.NonInteractive;
using Plugins.UIManager.Scripts.Components.NonInteractive.UITimer;
using Zenject;

public class UIComponentInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindNonInteractiveComponentDependencies();
        Container.BindTimerColoringDependencies();
        Container.BindTimerFormattingDependencies();
    }
}