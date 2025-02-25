using System.Collections;
using System.Collections.Generic;
using PetrushevskiApps.UIManager;
using UnityEngine;
using UnityEngine.Events;

public class InteractivityMonitor : SelectableExtension
{
    public UnityEvent<bool> InteractivityChangedEvent = new();

    private bool _currentStatus;
    private Coroutine _checkCoroutine;

    private void OnEnable()
    {
        StartCheck();
    }

    private void OnDisable()
    {
        StopCheck();
    }

    private void StartCheck()
    {
        StopCheck();
        _currentStatus = Selectable.interactable;
        _checkCoroutine = StartCoroutine(InteractivityCheck());
    }

    private void StopCheck()
    {
        if (_checkCoroutine == null)
        {
            return;
        }
        StopCoroutine(_checkCoroutine);
        _checkCoroutine = null;
    }

    private IEnumerator InteractivityCheck()
    {
        yield return new WaitUntil(()=> Selectable.interactable != _currentStatus);
        InteractivityChangedEvent.Invoke(Selectable.interactable);
        StartCheck();
    }
}
