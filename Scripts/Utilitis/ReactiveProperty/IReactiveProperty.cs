namespace MenuManager.Scripts.Utilitis
{
    public interface IReactiveProperty<T> : IReadOnlyReactiveProperty<T>
    {
        T Value { get; set; }
    }
}