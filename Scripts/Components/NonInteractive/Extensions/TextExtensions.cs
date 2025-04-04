using TMPro;

namespace MenuManager.Scripts.Components.NonInteractive.Extensions
{
    public static class TextExtensions
    {
        public static void SetData(this TextMeshProUGUI textMeshProUGUI, string text)
        {
            textMeshProUGUI.text = text;
        }
    }
}