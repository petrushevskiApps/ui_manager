using System;
using UnityEngine;

public class ConnectionListenerDummyAdapter : MonoBehaviour, IConnectionListener
{
    public void RegisterToConnectionChanges(Action<bool> onConnectionChanges)
    {
        return;
    }

    public void UnregisterToConnectionChanges(Action<bool> onConnectionChanges)
    {
        return;
    }
}
