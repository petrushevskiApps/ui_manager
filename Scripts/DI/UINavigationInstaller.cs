using TwoOneTwoGames.UIManager.ScreenNavigation;
using Zenject;

namespace TwoOneTwoGames.UIManager.Di
{
    public class UINavigationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindNavigationControllerDependencies();
            Container.BindScreenNavigationDependencies();
            Container.BindPopupNavigationDependencies();
        }
    }
}