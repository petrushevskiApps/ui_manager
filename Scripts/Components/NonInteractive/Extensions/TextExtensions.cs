using TMPro;

namespace MenuManager.Scripts.Components.NonInteractive.Extensions
{
    public static class TextExtensions
    {
        public static void SetData(this TextMeshProUGUI textMeshProUGUI, string text)
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