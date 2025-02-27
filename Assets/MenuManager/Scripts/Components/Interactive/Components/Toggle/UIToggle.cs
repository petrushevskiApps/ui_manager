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
                    onValueChanged.Invoke(isOn);
                }
                
            }
        }

        protected override void Awake()
        {
            base.Awake();
            onValueChanged.AddListener(OnValueChanged);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            onValueChanged.RemoveListener(OnValueChanged);
        }
        private void OnValueChanged(bool arg0)
        {
            StateChangedEvent.Invoke();
        }
    }
}


