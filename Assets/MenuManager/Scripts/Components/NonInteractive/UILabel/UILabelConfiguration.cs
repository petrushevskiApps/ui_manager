using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "Label Configuration", 
    menuName = "Data/Label Configuration", order = 1)]
public class UILabelConfiguration : ScriptableObject
{
    [SerializeField]
    private List<LabelStyleData> stylesData;

    public LabelStyleData GetStyle(LabelState state)
    {
        return stylesData.Find(style => style.State == state);
    }
}