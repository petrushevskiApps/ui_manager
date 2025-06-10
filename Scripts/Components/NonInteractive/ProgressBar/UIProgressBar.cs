using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TwoOneTwoGames.UIManager.Components.NonInteractive
{
    [RequireComponent(typeof(Slider))]
    public class UIProgressBar : MonoBehaviour
    {
        [SerializeField]
        private Image _fillImage;

        [SerializeField]
        private TextMeshProUGUI _text;

        private float _currentProgress;
        private float _maxProgress;

        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        public void SetData(UIProgressBarData progressBarData)
        {
            if (!progressBarData.IsVisible)
            {
                gameObject.SetActive(false);
                return;
            }
            gameObject.SetActive(true);
            _slider.minValue = progressBarData.Minimum;
            _slider.maxValue = progressBarData.Maximum;
            UpdateProgress(progressBarData.Current);

            if (progressBarData.Color.HasValue) SetColor(progressBarData.Color.Value);
        }

        private void UpdateProgress(float currentProgress)
        {
            _slider.value = currentProgress;
            UpdateText();
        }

        private void SetColor(Color color)
        {
            _fillImage.color = color;
        }

        private void UpdateText()
        {
            if (_text != null) _text.text = $"{_slider.value} / {_slider.maxValue}";
        }
    }
}