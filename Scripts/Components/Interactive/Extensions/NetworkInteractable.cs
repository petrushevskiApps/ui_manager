using PetrushevskiApps.UIManager;
using UnityEngine;
using Zenject;

/// <summary>
/// This component extends the functionality of a Selectable
/// component ( for example: Buttons, Toggles, Input Fields )
/// and changes their interactivity depending on the Network
/// connectivity state.
/// </summary>
[RequireComponent(typeof(InteractivityMonitor))]
public class NetworkInteractable : SelectableExtension
{
    private IConnectionListener _connectionListener;
    private InteractivityMonitor _interactivityMonitor;

    public bool IsConnected { get; private set; }

    [Inject]
    public void Initialize(IConnectionListener connectionListener)
    {
        _connectionListener = connectionListener;
    }

    protected new void Awake()
    {
        base.Awake();
        _interactivityMonitor = GetComponent<InteractivityMonitor>();
    }
    private void Start()
    {
        _connectionListener?.RegisterToConnectionChanges(OnConnectionChange);
        if (_interactivityMonitor != null)
        {
            _interactivityMonitor.InteractivityChangedEvent.AddListener(OnInteractivityChange);
        }
    }

    private void OnDestroy()
    {
        _connectionListener?.UnregisterToConnectionChanges(OnConnectionChange);
        if (_interactivityMonitor != null)
        {
            _interactivityMonitor.InteractivityChangedEvent.RemoveListener(OnInteractivityChange);
        }
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

    private void SetConnectivityStatus()
    {
        if (Selectable != null)
        {
            Selectable.interactable &= IsConnected;
        }
    }
}
