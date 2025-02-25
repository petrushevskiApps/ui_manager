using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILabel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textHolder;

    [SerializeField]
    private Image _iconImage;

    [SerializeField]
    private LabelState _state;

    [SerializeField]
    private UILabelConfiguration _configuration;

    private void OnEnable()
    {
        Setup();
    }

    public void SetText(string text)
    {
        if (text != null)
        {
            _textHolder.text = text;
            Setup();
        }
    }

    public void SetIcon(Sprite icon)
    {
        if (icon != null)
        {
            _iconImage.sprite = icon;
        }
    }

    public void SetState(LabelState newState)
    {
        _state = newState;
        Setup();
    }

    private void Setup()
    {
        if (_configuration == null)
        {
            return;
        }
        
        LabelStyleData styleData = _configuration.GetStyle(_state);

        if (_textHolder != null)
        {
            _textHolder.fontStyle = styleData.FontStyle;
            _textHolder.color = styleData.Color;
        }

        if (_iconImage != null)
        {
            _iconImage.color = styleData.Color;
        }
    }
}