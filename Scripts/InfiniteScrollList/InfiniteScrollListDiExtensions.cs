using Zenject;

namespace TinyRiftGames.UIManager.Scripts.InfiniteScrollList
{
    public static class InfiniteScrollListDiExtensions
    {
        public static void BindInfiniteScrollListDependencies(this DiContainer container)
        {
            container
                .Bind<IItemViewPool>()
                .To<ItemViewPool>()
                .AsTransient();
        }
    }
}