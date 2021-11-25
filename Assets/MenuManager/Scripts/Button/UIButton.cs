using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PetrushevskiApps.UIManager
{
    public class UIButton : Button
    {
        public UnityEvent InteractableChangedEvent = new UnityEvent();

        public new bool IsInteractable
        {
            get => interactable;
            set
            {
                if (interactable != value)
                {
                    interactable = value;
                    InteractableChangedEvent.Invoke();
                }
            }
        }
        
        
        protected override void OnDestroy()
        {
            base.OnDestroy();
            onClick.RemoveAllListeners();
        }

    }
}