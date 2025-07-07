using System;
using TMPro;
using TwoOneTwoGames.UIManager.Interfaces;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Components.Interactive.FunnelSelection
{
    public class UnlockFunnelButton : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _currencyCost;

        private UIButton _button;

        // Internal
        private int _loadedFunnelCost;

        // Injected
        private IUiFunnelPresenter _funnelPresenter;
        private IUiFunnelController _funnelController;
        private IUiGameEconomyPresenter _gameEconomyPresenter;
        private IUiGameEconomyController _gameEconomyController;

        [Inject]
        public void Initialize(
            IUiFunnelPresenter funnelPresenter,
            IUiFunnelController funnelController,
            IUiGameEconomyPresenter gameEconomyPresenter,
            IUiGameEconomyController gameEconomyController)
        {
            _funnelPresenter = funnelPresenter;
            _funnelController = funnelController;
            _gameEconomyPresenter = gameEconomyPresenter;
            _gameEconomyController = gameEconomyController;
        }

        private void Awake()
        {
            _button = GetComponent<UIButton>();
            _funnelPresenter.FunnelLoadedEvent += OnFunnelLoaded;
            _funnelPresenter.FunnelUnlockedEvent += OnFunnelUnlocked;
        }

        private void OnDestroy()
        {
            _funnelPresenter.FunnelLoadedEvent -= OnFunnelLoaded;
            _funnelPresenter.FunnelUnlockedEvent -= OnFunnelUnlocked;
        }

        private void OnEnable()
        {
            SetData();
        }

        private void OnFunnelLoaded(object sender, EventArgs e)
        {
            SetData();
        }

        private void OnFunnelUnlocked(object sender, int funnelId)
        {
            SetData();
        }

        private void SetData()
        {
            _loadedFunnelCost = _funnelPresenter.GetFunnelCost();
            bool sufficientResources = _gameEconomyPresenter.GetResourceValueWithId(0) >= _loadedFunnelCost;
            _button.SetData(new UIButtonViewData(
                "Unlock Puzzle Set",
                clickAction: OnButtonClicked,
                isVisible: _funnelPresenter.IsLockedFunnel(),
                isInteractive: sufficientResources));
            _currencyCost.text = _loadedFunnelCost.ToString();
            _currencyCost.color = sufficientResources ? Color.white : Color.yellow;
        }

        private void OnButtonClicked()
        {
            if (_gameEconomyPresenter.GetResourceValueWithId(0) >= _loadedFunnelCost)
            {
                _gameEconomyController.UseCurrency(0, _loadedFunnelCost);
                _funnelController.UnlockFunnel();
            }
        }
    }
}