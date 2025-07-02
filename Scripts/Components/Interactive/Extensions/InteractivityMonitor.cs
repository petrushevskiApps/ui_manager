using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace TwoOneTwoGames.UIManager.Components.Interactive
{
    public class InteractivityMonitor : SelectableExtension
    {
        public UnityEvent<bool> InteractivityChangedEvent = new();
        public bool IsInteractive => _currentStatus;
        
        // Internal
        private Coroutine _checkCoroutine;
        private bool _currentStatus;

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
            InteractivityChangedEvent.Invoke(_currentStatus);
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
            yield return new WaitUntil(() => Selectable.interactable != _currentStatus);
            InteractivityChangedEvent.Invoke(Selectable.interactable);
            StartCheck();
        }
    }
}