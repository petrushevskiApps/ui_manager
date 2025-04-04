using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace PetrushevskiApps.UIManager
{
    [RequireComponent(typeof(Button))]
    public class UIButton : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _label;

        private Button _button;

        public UnityEvent OnClick;

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
            _button.onClick.AddListener(OnClick.Invoke);
        }

        protected void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }
    }
}