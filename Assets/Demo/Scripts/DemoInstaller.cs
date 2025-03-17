using MenuManager.Scripts.Adapters;
using Zenject;

namespace Demo.Scripts
{
    public class DemoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindUiSoundSystemDependencies();
            Container.BindNetworkSystemDependencies();
            Container.BindLevelControllerDependencies();
            Container.BindSettingsStateControllerDependencies();
        }
    }
}