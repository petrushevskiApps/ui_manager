using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UILabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textHolder;
    [SerializeField] private Image iconImage;
    
    [SerializeField] private LabelState state;
    [SerializeField] private UILabelConfiguration configuration;
    private void OnEnable()
    {
        Setup();
    }

    public void SetText(string text)
    {
        if (text != null)
        {
            textHolder.text = text;
            Setup();
        }
    }

    public void SetIcon(Sprite icon)
    {
        if (icon != null)
        {
            iconImage.sprite = icon;
        }
    }

    public void SetState(LabelState newState)
    {
        state = newState;
        Setup();
    }
    
    private void Setup()
    {
        if(configuration == null) return;
        
        LabelStyleData styleData = configuration.GetStyle(state);

        if (textHolder != null)
        {
            textHolder.fontStyle = styleData.fontStyle;
            textHolder.color = styleData.color;
        }

        if (iconImage != null)
        {
            iconImage.color = styleData.color;
        }
    }
}
