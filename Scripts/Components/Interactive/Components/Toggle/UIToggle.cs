using System;
using MenuManager.Scripts.Components.NonInteractive.Extensions;
using slowBulletGames.MemoryValley;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace com.petrushevskiapps.menumanager
{
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
        
        // Injected
        private IUiHapticsController _uiHapticsController;

        [Inject]
        public void Initialize(IUiHapticsController uiHapticsController)
        {
            _uiHapticsController = uiHapticsController;
        }
        
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
            _uiHapticsController.Toggle(state);
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


