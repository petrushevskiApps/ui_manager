using TMPro;
using UnityEngine;
using Zenject;

namespace Plugins.UIManager.Scripts.Components.NonInteractive.UITimer
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class UITimerLabel : MonoBehaviour
    {
        private TextMeshProUGUI _label;
        
        // Internal
        private string _animationState;
        
        // Injected
        private ITimerColoringStrategy _timerColoringStrategy;
        private ITimerFormattingStrategy _timerFormattingStrategy;
        
        [Inject]
        public void Initialize(
            ITimerColoringStrategy timerColoringStrategy,
            ITimerFormattingStrategy timerFormattingStrategy)
        {
            _timerColoringStrategy = timerColoringStrategy;
            _timerFormattingStrategy = timerFormattingStrategy;
        }

        private void Awake()
        {
            _label = GetComponent<TextMeshProUGUI>();
        }

        public void SetData(UITimerData data)
        {
            gameObject.SetActive(data.IsVisible);
            if (!data.IsVisible)
            {
                return;
            }
            int minutes = GetMinutes(data.Seconds);
            int seconds = GetSeconds(minutes, data.Seconds);
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
            return totalSeconds - (minutes * 60);
        }
    }
}