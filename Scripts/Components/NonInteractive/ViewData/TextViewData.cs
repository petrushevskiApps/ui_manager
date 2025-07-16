using UnityEngine;

namespace TwoOneTwoGames.UIManager.Components.NonInteractive.NonInteractive.ViewData
{
    public struct TextViewData
    {
        public bool IsActive;
        public string Text;
        public Color Color;

        public TextViewData(bool isActive = false, string text = "", Color color = default)
        {
            IsActive = isActive;
            Text = text;
            Color = color;
        }
    }
}