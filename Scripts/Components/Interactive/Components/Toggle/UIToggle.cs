using System;
using MenuManager.Scripts.Components.NonInteractive.Extensions;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace com.petrushevskiapps.menumanager
{
    public record ViewData
    {
        public bool IsActive { get; set; }
    }
    
    public record ToggleViewData: ViewData
    {
        public string Label { get; set; }
        public bool State { get;  set; }
        public Action OnToggleStateChanged { get; set; }
    }
    
    [RequireComponent(typeof(Toggle))]
    public class UIToggle : MonoBehaviour
    {
        [SerializeField] 
        private Toggle _toggle;
        [SerializeField] 
        public TextMeshProUGUI _label;
        [SerializeField] 
        private GameObject _toggleOnState;
        [SerializeField] 
        private GameObject _toggleOffState;

        // Internal
        private Action _onToggleStateChanged;
        protected void Awake()
        {
            _toggle.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDestroy()
        {
            _toggle.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(bool state)
        {
            SetToggleState(state);
            _onToggleStateChanged?.Invoke();
        }

        private void SetToggleState(bool state)
        {
            _toggle.isOn = state;
            if (_toggleOnState != null)
            {
                _toggleOnState.SetActive(state);
            }

            if (_toggleOffState != null)
            {
                _toggleOffState.SetActive(!state);
            }
        }

        public void SetData(ToggleViewData viewData)
        {
            gameObject.SetActive(viewData?.IsActive ?? false);
            if (viewData == null || !viewData.IsActive)
            {
                return;
            }
            _label.SetData(viewData.Label);
            SetToggleState(viewData.State);
            _onToggleStateChanged = viewData.OnToggleStateChanged;
        }
    }
}


