using System;
using slowBulletGames.MemoryValley;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace PetrushevskiApps.UIManager
{
    [RequireComponent(typeof(Button))]
    public class UIButton : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _label;

        [SerializeField]
        private bool _ignoreHaptics;
        
        private Button _button;

        public UnityEvent OnClick;
        
        // Injected
        private IUiHapticsController _uiHapticsController;

        [Inject]
        public void Initialize(IUiHapticsController uiHapticsController)
        {
            _uiHapticsController = uiHapticsController;
        }
        protected void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void SetData(UIButtonViewData viewData)
        {
            gameObject.SetActive(viewData.IsVisible);
            if (viewData.IsVisible)
            {
                _label.text = viewData.Label;
            }
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(ButtonClicked);
        }

        protected void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void ButtonClicked()
        {
            OnClick.Invoke();
            if (_ignoreHaptics)
            {
                return;
            }
            _uiHapticsController.ButtonClick();
        }
    }
}