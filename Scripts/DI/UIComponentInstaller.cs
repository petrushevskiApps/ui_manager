using TwoOneTwoGames.UIManager.Components.NonInteractive;
using TwoOneTwoGames.UIManager.InfiniteScrollList;
using TwoOneTwoGames.UIManager.JoystickController;
using Zenject;

namespace TwoOneTwoGames.UIManager.Di
{
    public class UIComponentInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindNonInteractiveComponentDependencies();
            Container.BindTimerColoringDependencies();
            Container.BindTimerFormattingDependencies();
            Container.BindJoystickDependencies();
            Container.BindInfiniteScrollListDependencies();
        }
    }
}