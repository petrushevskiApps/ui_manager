using TwoOneTwoGames.UIManager.Plugins.JoystickPlugin;
using Zenject;

namespace TwoOneTwoGames.UIManager.JoystickController
{
    public static class JoystickDiExtensions
    {
        public static void BindJoystickDependencies(this DiContainer container)
        {
            container
                .Bind<IJoystick>()
                .To<Plugins.JoystickPlugin.Joystick>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}