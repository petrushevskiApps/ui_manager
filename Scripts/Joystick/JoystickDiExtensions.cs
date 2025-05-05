using Zenject;

namespace Plugins.UIManager.Scripts.CustomJoystick
{
    public static class JoystickDiExtensions
    {
        public static void BindJoystickDependencies(this DiContainer container)
        {
            container
                .Bind<IJoystick>()
                .To<Joystick>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}