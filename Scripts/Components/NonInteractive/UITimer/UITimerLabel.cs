using TMPro;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Components.NonInteractive
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class UITimerLabel : MonoBehaviour
    {
        // Internal
        private string _animationState;
        private TextMeshProUGUI _label;

        // Injected
        private ITimerColoringStrategy _timerColoringStrategy;
        private ITimerFormattingStrategy _timerFormattingStrategy;

        private void Awake()
        {
            _label = GetComponent<TextMeshProUGUI>();
        }

        [Inject]
        public void Initialize(
            ITimerColoringStrategy timerColoringStrategy,
            ITimerFormattingStrategy timerFormattingStrategy)
        {
            _timerColoringStrategy = timerColoringStrategy;
            _timerFormattingStrategy = timerFormattingStrategy;
        }

        public void SetData(UITimerData data)
        {
            gameObject.SetActive(data.IsVisible);
            if (!data.IsVisible) return;
            var minutes = GetMinutes(data.Seconds);
            var seconds = GetSeconds(minutes, data.Seconds);
            SetLabel(minutes, seconds);
        }

        private void SetLabel(int minutes, int seconds)
        {
            _label.text = $"{_timerFormattingStrategy.GetFormattedTimer(minutes, seconds)}";
            _label.color = _timerColoringStrategy.GetTimerLabelColor(minutes, seconds);
        }

        private int GetMinutes(int totalSeconds)
        {
            return totalSeconds / 60;
        }

        private int GetSeconds(int minutes, int totalSeconds)
        {
            return totalSeconds - minutes * 60;
        }
    }
}