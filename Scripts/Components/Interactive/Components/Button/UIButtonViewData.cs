using System;
using UnityEngine;

namespace TwoOneTwoGames.UIManager.Components.Interactive
{
    public struct UIButtonViewData
    {
        public bool IsVisible { get; }
        public bool IsInteractive { get; }
        public string Label { get; }
        public Color? TextColor { get; }
        public Action ClickAction { get; }

        public UIButtonViewData(
            string label = null, 
            Color? textColor = null, 
            Action clickAction = null,
            bool isInteractive = true,
            bool isVisible = true)
        {
            IsVisible = isVisible;
            IsInteractive = isInteractive;
            Label = label;
            TextColor = textColor;
            ClickAction = clickAction;
        }
    }
}