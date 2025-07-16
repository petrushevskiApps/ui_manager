using TMPro;
using TwoOneTwoGames.UIManager.Components.NonInteractive.NonInteractive.ViewData;

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
        
        public static void SetData(this TextMeshProUGUI textMeshProUGUI, TextViewData data)
        {
            if (!data.IsActive)
            {
                textMeshProUGUI.gameObject.SetActive(false);
                return;
            }

            textMeshProUGUI.text = data.Text;
            textMeshProUGUI.color = data.Color;
            textMeshProUGUI.gameObject.SetActive(true);
        }
    }
}