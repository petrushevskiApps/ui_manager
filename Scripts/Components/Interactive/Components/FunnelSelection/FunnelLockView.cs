using System;
using TwoOneTwoGames.UIManager.Interfaces;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Components.Interactive.FunnelSelection
{
    public class FunnelLockView: MonoBehaviour
    {
        // Injected
        private IUiFunnelPresenter _funnelPresenter;

        [Inject]
        public void Initialize(
            IUiFunnelPresenter funnelPresenter)
        {
            _funnelPresenter = funnelPresenter;
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
            gameObject.SetActive(_funnelPresenter.IsLockedFunnel());
        }
    }
}