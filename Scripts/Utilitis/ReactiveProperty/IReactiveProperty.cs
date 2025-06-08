namespace TwoOneTwoGames.UIManager.Utilities.ReactiveProperty
{
    public interface IReactiveProperty<T> : IReadOnlyReactiveProperty<T>
    {
        T Value { get; set; }
    }
}