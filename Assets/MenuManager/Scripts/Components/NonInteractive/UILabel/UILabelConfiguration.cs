using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Label Configuration", menuName = "Data/Label Configuration", order = 1)]
public class UILabelConfiguration : ScriptableObject
{
    [SerializeField] private List<LabelStyleData> stylesData;

    public LabelStyleData GetStyle(LabelState state)
    {
        return stylesData.Find(style => style.labelState == state);
    }
}

[Serializable]
public class LabelStyleData
{
    public LabelState labelState;
    public FontStyles fontStyle;
    public Color color;
}

public enum LabelState
{
    Normal,
    Warning,
    Error,
}