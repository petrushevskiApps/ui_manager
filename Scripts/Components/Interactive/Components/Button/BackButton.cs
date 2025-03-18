using System;
using UnityEngine;
using Zenject;

namespace PetrushevskiApps.UIManager
{
    public class BackButton : MonoBehaviour
    {
        public event EventHandler BackButtonClickedEvent;
        
        private UIButton _backButton;
        private INavigationController _navigationController;

        [Inject]
        private void Initialize(INavigationController navigationController)
        {
            _navigationController = navigationController;
        }
        private void Awake()
        {
            _backButton = gameObject.GetComponent<UIButton>();
        }

        private void OnEnable()
        {
            if (_backButton != null)
            {
                _backButton.onClick.AddListener(OnClick);
            }
        }

        private void OnDisable()
        {
            if (_backButton != null)
            {
                _backButton.onClick.RemoveListener(OnClick);
            }
        }

        private void OnClick()
        {
            BackButtonClickedEvent?.Invoke(this, EventArgs.Empty);
            _navigationController?.GoBack();
        }
    }
}

