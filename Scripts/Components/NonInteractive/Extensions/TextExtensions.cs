using TMPro;

namespace TwoOneTwoGames.UIManager.Components.NonInteractive
{
    public static class TextExtensions
    {
        public static void SetData(this TextMeshProUGUI textMeshProUGUI, string text = null)
        {
            if (text == null)
            {
                textMeshProUGUI.gameObject.SetActive(false);
                return;
            }

            textMeshProUGUI.text = text;
            textMeshProUGUI.gameObject.SetActive(true);
        }
    }
}