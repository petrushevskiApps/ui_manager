using System;
using System.Collections;
using System.Collections.Generic;
using com.petrushevskiapps.menumanager;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ToggleText : MonoBehaviour
{
    [SerializeField]
    private UIToggle _toggle;

    [SerializeField]
    private ToggleTextConfig _config;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _toggle.StateChangedEvent.AddListener(SetToggleText);
    }

    private void OnDestroy()
    {
        _toggle.StateChangedEvent.RemoveListener(SetToggleText);
    }

    private void OnEnable()
    {
        SetToggleText();
    }

    private void SetToggleText()
    {
        if (_config != null)
        {
            _text.text = _config.GetText(_toggle.IsOn);
            _text.fontStyle = _config.GetFontStyle(_toggle.IsOn);
        }
    }
}