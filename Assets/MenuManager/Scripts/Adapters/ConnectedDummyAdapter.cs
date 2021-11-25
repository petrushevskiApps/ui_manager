using System;
using UnityEngine;

public class ConnectedDummyAdapter : MonoBehaviour, IConnected
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
