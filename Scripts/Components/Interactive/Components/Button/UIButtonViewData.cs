using System;
using TwoOneTwoGames.UIManager.Components.NonInteractive.NonInteractive.ViewData;
using UnityEngine;

namespace TwoOneTwoGames.UIManager.Components.Interactive
{
    public struct UIButtonViewData
    {
        public bool IsVisible { get; }
        public bool IsInteractive { get; }
        public TextViewData Label { get; }
        public Color? TextColor { get; }
        public Action ClickAction { get; }
        public ImageViewData? FirstIcon { get; }
        public ImageViewData? SecondIcon { get; }

        public UIButtonViewData(
            TextViewData label = default, 
            Color? textColor = null, 
            Action clickAction = null,
            ImageViewData? firstIcon = null,
            ImageViewData? secondIcon = null,
            bool isInteractive = true,
            bool isVisible = true)
        {
            IsVisible = isVisible;
            IsInteractive = isInteractive;
            Label = label;
            TextColor = textColor;
            ClickAction = clickAction;
            FirstIcon = firstIcon;
            SecondIcon = secondIcon;
        }
    }
}