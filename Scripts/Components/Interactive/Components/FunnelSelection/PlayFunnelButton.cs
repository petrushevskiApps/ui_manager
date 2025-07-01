using System;
using TwoOneTwoGames.UIManager.Interfaces;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Components.Interactive.FunnelSelection
{
    public class PlayFunnelButton: MonoBehaviour
    {
        private UIButton _button;
        
        // Injected
        private IUiFunnelPresenter _funnelPresenter;
        private ILevelsDataProvider _levelsDataProvider;
        private IUILevelController _uiLevelController;

        [Inject]
        public void Initialize(
            IUiFunnelPresenter funnelPresenter,
            ILevelsDataProvider levelsDataProvider,
            IUILevelController uiLevelController)
        {
            _funnelPresenter = funnelPresenter;
            _levelsDataProvider = levelsDataProvider;
            _uiLevelController = uiLevelController;
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
            _button.OnClick.AddListener(OnButtonClicked);
            SetData();
        }

        private void OnDisable()
        {
            _button.OnClick.RemoveListener(OnButtonClicked);
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
            _button.SetData(new UIButtonViewData()
            {
                Label = $"Play Level {_levelsDataProvider.GetLastUnlockedLevel().Id + 1}",
                IsVisible = !_funnelPresenter.IsLockedFunnel(),
                IsInteractive = true
            });
        }

        private void OnButtonClicked()
        {
            _uiLevelController.StartLevel();
        }
    }
}