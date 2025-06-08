using System;

namespace TwoOneTwoGames.UIManager.Interfaces
{
    public interface IConnectionListener
    {
        void RegisterToConnectionChanges(Action<bool> onConnectionChanges);
        void UnregisterToConnectionChanges(Action<bool> onConnectionChanges);
    }
}