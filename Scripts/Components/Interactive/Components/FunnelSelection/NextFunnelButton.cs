using System;
using TwoOneTwoGames.UIManager.Interfaces;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Components.Interactive.FunnelSelection
{
    public class NextFunnelButton: MonoBehaviour
    {
        private UIButton _button;
        
        // Injected
        private IUiFunnelPresenter _funnelPresenter;
        private IUiFunnelController _funnelController;

        [Inject]
        public void Initialize(
            IUiFunnelPresenter funnelPresenter,
            IUiFunnelController funnelController)
        {
            _funnelPresenter = funnelPresenter;
            _funnelController = funnelController;
        }

        private void Awake()
        {
            _button = GetComponent<UIButton>();
        }

        private void OnEnable()
        {
            _funnelPresenter.FunnelLoadedEvent += OnFunnelLoaded;
            _button.OnClick.AddListener(OnButtonClicked);
            SetData();
        }

        private void OnDisable()
        {
            _funnelPresenter.FunnelLoadedEvent -= OnFunnelLoaded;
            _button.OnClick.RemoveListener(OnButtonClicked);
        }

        private void OnFunnelLoaded(object sender, EventArgs e)
        {
            SetData();
        }

        private void SetData()
        {
            _button.SetData(new UIButtonViewData()
            {
                IsInteractive = !_funnelPresenter.IsLastFunnel(),
                IsVisible = true
            });
        }

        private void OnButtonClicked()
        {
            _funnelController.LoadNextFunnel();
        }
    }
}