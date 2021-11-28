using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Toggle Text Config", menuName = "Data/Toggle Text", order = 1)]
public class ToggleTextConfig : ScriptableObject
{
    [SerializeField] private string toggleOnText;
    [SerializeField] private string toggleOffText;
    
    [SerializeField] private FontStyles onFontStyle;
    [SerializeField] private FontStyles offFontStyle;

    public string GetText(bool isOn) => isOn ? toggleOnText : toggleOffText;
    public FontStyles GetFontStyle(bool isOn) => isOn ? onFontStyle : offFontStyle;
    
}
