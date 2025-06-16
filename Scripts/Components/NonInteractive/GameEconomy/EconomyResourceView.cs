﻿using System.Globalization;
using TMPro;
using TwoOneTwoGames.UIManager.Data.IconPalette;
using TwoOneTwoGames.UIManager.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace TwoOneTwoGames.UIManager.Components.NonInteractive.GameEconomy
{
    public class EconomyResourceView: MonoBehaviour
    {
        [SerializeField]
        private int _resourceId;
        [SerializeField]
        private Image _resourceIcon;
        [SerializeField]
        private TextMeshProUGUI _resourceValueText;

        // Injected
        private IUiGameEconomyPresenter _gameEconomyPresenter;
        private IUiGameEconomyIconPalette _uiGameEconomyIconPalette;

        [Inject]
        public void Initialize(
            IUiGameEconomyIconPalette uiGameEconomyIconPalette,
            IUiGameEconomyPresenter gameEconomyPresenter)
        {
            _uiGameEconomyIconPalette = uiGameEconomyIconPalette;
            _gameEconomyPresenter = gameEconomyPresenter;
            _gameEconomyPresenter.EarnedResourceEvent += OnEarnedReward;
        }
        
        private void OnDestroy()
        {
            _gameEconomyPresenter.EarnedResourceEvent -= OnEarnedReward;
        }

        private void OnEarnedReward(object sender, (int id, float value) resource)
        {
            if (_resourceId != resource.id)
            {
                return;
            }
            SetValue(resource.value);
            SetIcon(resource.id);
        }

        private void SetValue(float value)
        {
            _resourceValueText.text = value.ToString(CultureInfo.InvariantCulture);
        }

        private void SetIcon(int rewardId)
        {
            _resourceIcon.sprite = _uiGameEconomyIconPalette.EconomyResourceIcons[rewardId];
        }
    }
}