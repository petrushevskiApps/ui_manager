using System.Collections;
using System.Collections.Generic;
using PetrushevskiApps.UIManager;
using UnityEngine;
using UnityEngine.UI;

public class NetworkButton : ButtonExtension
{
    private IConnected iConnected;

    public bool IsConnected { get; private set; }

    private UIButton button;

    private void Start()
    {
        button = GetComponent<UIButton>();
        iConnected = UIManager.Instance.IConnected;

        iConnected?.RegisterToConnectionChanges(OnConnectionChange);
        button?.InteractableChangedEvent.AddListener(SetConnectivityStatus);
    }

    private void OnDestroy()
    {
        iConnected?.UnregisterToConnectionChanges(OnConnectionChange);
        button?.InteractableChangedEvent.RemoveListener(SetConnectivityStatus);
    }

    private void OnConnectionChange(bool isConnected)
    {
        IsConnected = isConnected;
        SetConnectivityStatus();
    }

    public void SetConnectivityStatus()
    {
        if (button != null)
        {
            button.interactable &= IsConnected;
        }
    }
}
