using Zenject;

namespace TwoOneTwoGames.UIManager.Components.NonInteractive
{
    public static class UIComponentsDiExtension
    {
        public static void BindNonInteractiveComponentDependencies(this DiContainer container)
        {
            container
                .Bind<IUIObjectPresenter>()
                .To<UIObjectPresenter>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}