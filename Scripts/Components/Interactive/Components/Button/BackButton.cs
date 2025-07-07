using System;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Components.Interactive
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
            if (_backButton != null)
            {
                _backButton.SetData(new UIButtonViewData(clickAction: OnClick));
            }
        }

        private void OnClick()
        {
            BackButtonClickedEvent?.Invoke(this, EventArgs.Empty);
            _navigationController?.GoBack();
        }
    }
}