using System;
public interface IConnected
{
    void RegisterToConnectionChanges(Action<bool> onConnectionChanges);
    void UnregisterToConnectionChanges(Action<bool> onConnectionChanges);

}
