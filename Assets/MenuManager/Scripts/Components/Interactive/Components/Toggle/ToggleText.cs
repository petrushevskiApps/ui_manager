using System;
using System.Collections;
using System.Collections.Generic;
using com.petrushevskiapps.menumanager;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ToggleText : MonoBehaviour
{
    [SerializeField] private UIToggle toggle;
    [SerializeField] private ToggleTextConfig config;
    private TextMeshProUGUI text;
    
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        toggle.StateChangedEvent.AddListener(SetToggleText);
    }

    private void OnDestroy()
    {
        toggle.StateChangedEvent.RemoveListener(SetToggleText);
    }

    private void OnEnable()
    {
        SetToggleText();
    }

    private void SetToggleText()
    {
        if (config != null)
        {
            text.text = config.GetText(toggle.IsOn);
            text.fontStyle = config.GetFontStyle(toggle.IsOn);
        }
    }
}