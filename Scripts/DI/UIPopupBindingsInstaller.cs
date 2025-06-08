using TwoOneTwoGames.UIManager.Windows;
using Zenject;

namespace TwoOneTwoGames.UIManager.Di
{
    public class UIPopupBindingsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindPopupDependencies();
        }
    }
}