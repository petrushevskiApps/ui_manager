using System;
using TMPro;
using TwoOneTwoGames.UIManager.Components.NonInteractive;
using TwoOneTwoGames.UIManager.Interfaces;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Components.Interactive.FunnelSelection
{
    public class FunnelTitle: MonoBehaviour
    {
        private TextMeshProUGUI _text;
        
        // Injected
        private IUiFunnelPresenter _funnelPresenter;

        [Inject]
        public void Initialize(
            IUiFunnelPresenter funnelPresenter)
        {
            _funnelPresenter = funnelPresenter;
        }

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }
        
        private void OnEnable()
        {
            _funnelPresenter.FunnelLoadedEvent += OnFunnelLoaded;
            SetData();
        }

        private void OnDisable()
        {
            _funnelPresenter.FunnelLoadedEvent -= OnFunnelLoaded;
        }
        
        private void OnFunnelLoaded(object sender, EventArgs e)
        {
            SetData();
        }
        
        private void SetData()
        {
            _text.SetData(_funnelPresenter.GetCurrentFunnelTitle());
        }
    }
}