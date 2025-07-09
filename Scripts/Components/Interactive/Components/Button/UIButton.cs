using System;
using TMPro;
using TwoOneTwoGames.UIManager.Components.NonInteractive;
using TwoOneTwoGames.UIManager.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TwoOneTwoGames.UIManager.Components.Interactive
{
    [RequireComponent(typeof(Button))]
    public class UIButton : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _label;
        [SerializeField]
        private Image _firstIcon;
        [SerializeField]
        private Image _secondIcon;
        
        [SerializeField]
        private bool _ignoreHaptics;

        public Action OnClick;

        private Button _button;

        // Injected
        private IUiHapticsController _uiHapticsController;

        protected void Awake()
        {
            _button ??= GetComponent<Button>();
            _button.onClick.AddListener(ButtonClicked);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ButtonClicked);
        }

        [Inject]
        public void Initialize(IUiHapticsController uiHapticsController)
        {
            _uiHapticsController = uiHapticsController;
        }

        public void SetHaptics(IUiHapticsController hapticsController)
        {
            _uiHapticsController = hapticsController;
        }

        public void SetData(UIButtonViewData viewData)
        {
            _button ??= GetComponent<Button>();
            gameObject.SetActive(viewData.IsVisible);
            if (viewData.IsVisible && _label != null)
            {
                _label.gameObject.SetActive(true);
                _label.text = viewData.Label;
            }
            else if (viewData.Label == null && _label != null)
            {
                _label.gameObject.SetActive(false);
            }

            if (viewData.TextColor != null)
            {
                _label.color = viewData.TextColor.Value;
            }

            if (_firstIcon != null && viewData.FirstIcon.HasValue)
            {
                _firstIcon.SetData(viewData.FirstIcon.Value);
            }
            
            if (_secondIcon != null && viewData.SecondIcon.HasValue)
            {
                _secondIcon.SetData(viewData.SecondIcon.Value);
            }
            
            OnClick = viewData.ClickAction;
            
            _button.interactable = viewData.IsInteractive;
        }

        private void ButtonClicked()
        {
            OnClick?.Invoke();
            if (_ignoreHaptics)
            {
                return;
            }

            _uiHapticsController?.ButtonClick();
        }
    }
}