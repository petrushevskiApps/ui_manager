using Zenject;

namespace MenuManager.Scripts.Components.NonInteractive
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