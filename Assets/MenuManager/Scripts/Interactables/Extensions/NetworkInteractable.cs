using System.Collections;
using System.Collections.Generic;
using PetrushevskiApps.UIManager;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InteractivityMonitor))]
public class NetworkInteractable : SelectableExtension
{
    private IConnected iConnected;
    private InteractivityMonitor interactivityMonitor;

    public bool IsConnected { get; private set; }

    private void Start()
    {
        iConnected = UIManager.Instance.IConnected;
        interactivityMonitor = GetComponent<InteractivityMonitor>();

        iConnected?.RegisterToConnectionChanges(OnConnectionChange);
        interactivityMonitor?.InteractivityChangedEvent.AddListener(OnInteractivityChange);
    }

    private void OnDestroy()
    {
        iConnected?.UnregisterToConnectionChanges(OnConnectionChange);
        interactivityMonitor?.InteractivityChangedEvent.RemoveListener(OnInteractivityChange);
    }

    private void OnInteractivityChange(bool isInteractive)
    {
        SetConnectivityStatus();
    }

    private void OnConnectionChange(bool isConnected)
    {
        IsConnected = isConnected;
        SetConnectivityStatus();
    }

    public void SetConnectivityStatus()
    {
        if (selectable != null)
        {
            selectable.interactable &= IsConnected;
        }
    }
}
