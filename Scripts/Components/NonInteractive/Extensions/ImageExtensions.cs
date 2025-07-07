using TwoOneTwoGames.UIManager.Components.NonInteractive.NonInteractive.ViewData;
using UnityEngine;
using UnityEngine.UI;

namespace TwoOneTwoGames.UIManager.Components.NonInteractive
{
    public static class ImageExtensions
    {
        public static void SetData(this Image image, Sprite sprite)
        {
            if (sprite == null)
            {
                image.gameObject.SetActive(false);
                return;
            }

            image.sprite = sprite;
            image.gameObject.SetActive(true);
        }
        
        public static void SetData(this Image image, ImageViewData imageViewData)
        {
            if (!imageViewData.IsActive)
            {
                image.gameObject.SetActive(false);
                return;
            }

            image.sprite = imageViewData.Sprite;
            image.color = imageViewData.Color;
            image.gameObject.SetActive(true);
        }
    }
}