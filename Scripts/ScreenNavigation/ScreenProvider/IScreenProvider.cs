
public interface IScreenProvider
{
    /// <summary>
    /// Find and return the screen of type T from list.
    /// </summary>
    /// <typeparam name="T">Inherited type of interface <see cref="IScreen"/></typeparam>
    /// <returns>Screen matching the provided type T inheriting interface <see cref="IScreen"/></returns>
    IScreen GetScreen<T>() where T : IScreen;
}
