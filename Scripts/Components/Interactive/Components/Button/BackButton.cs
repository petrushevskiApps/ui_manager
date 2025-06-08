using System;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Components.Interactive
{
    public class BackButton : MonoBehaviour
    {
        private UIButton _backButton;
        private INavigationController _navigationController;

        private void Awake()
        {
            _backButton = gameObject.GetComponent<UIButton>();
        }

        private void OnEnable()
        {
            if (_backButton != null) _backButton.OnClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            if (_backButton != null) _backButton.OnClick.RemoveListener(OnClick);
        }

        public event EventHandler BackButtonClickedEvent;

        [Inject]
        private void Initialize(INavigationController navigationController)
        {
            _navigationController = navigationController;
        }

        private void OnClick()
        {
            BackButtonClickedEvent?.Invoke(this, EventArgs.Empty);
            _navigationController?.GoBack();
        }
    }
}