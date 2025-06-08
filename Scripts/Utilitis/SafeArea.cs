using UnityEngine;

namespace TwoOneTwoGames.UIManager.Utilities
{
    public class SafeArea : MonoBehaviour
    {
        [SerializeField]
        private bool activateSafeArea;

        private RectTransform screenRect;

        protected void Awake()
        {
            screenRect = GetComponent<RectTransform>();
        }

        protected void OnEnable()
        {
            if (activateSafeArea) ApplySafeArea();
        }

        private void ApplySafeArea()
        {
            var safeArea = Screen.safeArea;

            // Convert safe area rectangle from absolute pixels to normalised anchor coordinates
            var anchorMin = safeArea.position;
            var anchorMax = safeArea.position + safeArea.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;
            screenRect.anchorMin = anchorMin;
            screenRect.anchorMax = anchorMax;

            Debug.Log("Safe area set");
        }
    }
}