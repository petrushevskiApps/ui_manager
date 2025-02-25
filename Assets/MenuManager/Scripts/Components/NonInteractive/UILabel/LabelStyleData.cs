using System;
using TMPro;
using UnityEngine;

[Serializable]
public class LabelStyleData
{
    public LabelState State { get; set; }
    public FontStyles FontStyle  { get; set; }
    public Color Color  { get; set; }
}