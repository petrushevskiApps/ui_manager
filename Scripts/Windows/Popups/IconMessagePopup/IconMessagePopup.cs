using System.Collections.Generic;
using System.Linq;
using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.Components.NonInteractive;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using TwoOneTwoGames.UIManager.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TwoOneTwoGames.ZenRings.UserInterface.Windows
{
    public class IconMessagePopup : UIPopup
    {
        [SerializeField]
        private Image _icon;
        [SerializeField]
        private Transform _buttonsParent;
        [SerializeField]
        private UIButton _buttonPrefab;
        
        // Internal
        private readonly List<UIButton> _buttons = new();

        // Injected
        private IIconMessagePopupViewModel _viewModel;

        protected override IPopupViewModel GetPopupViewModel()
        {
            return _viewModel;
        }

        [Inject]
        private void Initialize(IIconMessagePopupViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public override void Show<TArguments>(TArguments navArguments)
        {
            if (navArguments is IconMessagePopupArguments arguments)
            {
                _viewModel.Setup(
                    arguments.Title,
                    arguments.Message,
                    arguments.Icon,
                    arguments.DiscardAction,
                    arguments.ButtonsViewData);
                SetupButtons(arguments.ButtonsViewData);
            }
            base.Show(navArguments);
        }

        private void SetupButtons(UIButtonViewData[] buttonsData)
        {
            if (_buttons.Count > buttonsData.Length)
            {
                _buttons.RemoveRange(0, _buttons.Count - buttonsData.Length);
            }
            else if (_buttons.Count < buttonsData.Length)
            {
                for (int i = 0; i < buttonsData.Length - _buttons.Count; i++)
                {
                    UIButton uiButton = Instantiate(_buttonPrefab, _buttonsParent);
                    uiButton.gameObject.AddComponent<ZenAutoInjecter>();
                    uiButton.OnClick += Close;
                    _buttons.Add(uiButton);
                }
            }
        }

        public override void Resume()
        {
            base.Resume();
            
            _viewModel.Icon.Subscribe(_icon.SetData);
            
            _viewModel.ButtonViews.Zip(_buttons, (property, button) => (property, button))
                .ToList()
                .ForEach(pair =>
                {
                    pair.property.Subscribe(pair.button.SetData);
                });
        }

        public override void Hide()
        {
            base.Hide();
            
            _viewModel.Icon.Unsubscribe(_icon.SetData);
            _viewModel.ButtonViews.Zip(_buttons, (property, button) => (property, button))
                .ToList()
                .ForEach(pair =>
                {
                    pair.property.Unsubscribe(pair.button.SetData);
                });
            _buttons.ForEach(button =>
            {
                button.OnClick -= Close;
                Destroy(button.gameObject);
            });
            _buttons.Clear();
        }
    }
}