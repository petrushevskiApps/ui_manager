using PetrushevskiApps.UIManager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace com.petrushevskiapps.menumanager
{
    public class UIToggle : Toggle
    {
        public UnityEvent StateChangedEvent = new UnityEvent();

        public bool IsOn
        {
            get => isOn;
            set
            {
                if (isOn != value)
                {
                    isOn = value;
                    StateChangedEvent.Invoke();
                }
                
            }
        }

    }
}


