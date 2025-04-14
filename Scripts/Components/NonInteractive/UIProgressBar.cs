using MenuManager.Scripts.Components.NonInteractive;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class UIProgressBar : MonoBehaviour
{
    [SerializeField]
    private Image _fillImage;
    [SerializeField]
    private TextMeshProUGUI _text;

    private Slider _slider;
    private float _currentProgress;
    private float _maxProgress;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void SetData(UIProgressBarData progressBarData)
    {
        _slider.minValue = progressBarData.Minimum;
        _slider.maxValue = progressBarData.Maximum;
        UpdateProgress(progressBarData.Current);
        
        if (progressBarData.Color.HasValue)
        {
            SetColor(progressBarData.Color.Value);
        }
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
        if (_text != null)
        {
            _text.text = $"{_slider.value} / {_slider.maxValue}";    
        }
    }
}
