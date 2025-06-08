using System;
using TMPro;
using TwoOneTwoGames.UIManager.Components.NonInteractive;
using TwoOneTwoGames.UIManager.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TwoOneTwoGames.UIManager.Components.Interactive
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

        protected void Awake()
        {
            _toggle.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDestroy()
        {
            _toggle.onValueChanged.RemoveListener(OnValueChanged);
        }

        [Inject]
        public void Initialize(IUiHapticsController uiHapticsController)
        {
            _uiHapticsController = uiHapticsController;
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
            if (_toggleOnState != null) _toggleOnState.SetActive(state);

            if (_toggleOffState != null) _toggleOffState.SetActive(!state);
        }

        public void SetData(ToggleViewData viewData)
        {
            gameObject.SetActive(viewData?.IsActive ?? false);
            if (viewData == null || !viewData.IsActive) return;
            _label.SetData(viewData.Label);
            SetToggleState(viewData.State);
            _onToggleStateChanged = viewData.OnToggleStateChanged;
        }
    }
}