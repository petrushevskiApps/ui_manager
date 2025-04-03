using MenuManager.Scripts.Components.NonInteractive;
using Zenject;

public class UIComponentInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindNonInteractiveComponentDependencies();
    }
}