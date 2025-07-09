using UnityEngine;

namespace TwoOneTwoGames.UIManager.Components.NonInteractive.NonInteractive.ViewData
{
    public struct ImageViewData
    {
        public bool IsActive;
        public Sprite Sprite;
        public Color Color;

        public ImageViewData(Color color = default, bool isActive = true, Sprite sprite = null)
        {
            IsActive = isActive;
            Sprite = sprite;
            Color = color;
        }
    }
}