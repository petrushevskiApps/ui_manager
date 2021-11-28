using System.Collections;
using System.Collections.Generic;
using PetrushevskiApps.UIManager;
using UnityEngine;
using UnityEngine.Events;

public class InteractivityMonitor : SelectableExtension
{
    public UnityEvent<bool> InteractivityChangedEvent = new UnityEvent<bool>();

    private bool currentStatus;
    private Coroutine checkCoroutine;

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
        currentStatus = selectable.interactable;
        checkCoroutine = StartCoroutine(InteractivityCheck());
    }

    private void StopCheck()
    {
        if (checkCoroutine != null)
        {
            StopCoroutine(checkCoroutine);
            checkCoroutine = null;
        }
    }

    private IEnumerator InteractivityCheck()
    {
        yield return new WaitUntil(()=> selectable.interactable != currentStatus);
        InteractivityChangedEvent.Invoke(selectable.interactable);
        StartCheck();
    }
}
