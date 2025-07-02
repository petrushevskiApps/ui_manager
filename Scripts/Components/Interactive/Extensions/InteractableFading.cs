using System;
using UnityEngine;

namespace TwoOneTwoGames.UIManager.Components.Interactive
{
    [RequireComponent(typeof(CanvasGroup))]
    public class InteractableFading : SelectableExtension
    {
        [SerializeField]
        private float _fadePercent = 0.6f;
        
        // Internal
        private InteractivityMonitor _interactivityMonitor;
        private CanvasGroup _canvasGroup;

        protected new void Awake()
        {
            base.Awake();
            _interactivityMonitor = GetComponent<InteractivityMonitor>();
            _canvasGroup = GetComponent<CanvasGroup>();
            
        }

        private void OnEnable()
        {
            if (_interactivityMonitor != null)
            {
                _interactivityMonitor.InteractivityChangedEvent.AddListener(OnInteractivityChange);
            }
            SetAlpha(_interactivityMonitor.IsInteractive);
        }

        private void OnDisable()
        {
            if (_interactivityMonitor != null)
            {
                _interactivityMonitor.InteractivityChangedEvent.RemoveListener(OnInteractivityChange);
            }
        }

        private void OnInteractivityChange(bool isInteractive)
        {
            SetAlpha(isInteractive);
        }

        private void SetAlpha(bool isInteractive)
        {
            _canvasGroup.alpha = isInteractive ? 1 : _fadePercent;
        }
    }
}