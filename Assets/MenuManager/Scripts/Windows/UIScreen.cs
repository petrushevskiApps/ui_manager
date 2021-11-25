using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PetrushevskiApps.UIManager
{
    public class UIScreen : UIWindow
    {
        [SerializeField] private bool activateSafeArea = true;
        [SerializeField] private List<GameObject> overlayElements;
        
        public static UnityEvent OnScreenShown = new UnityEvent();
        public static UnityEvent OnScreenHiden = new UnityEvent();
        public static UnityEvent OnScreenOpen = new UnityEvent();
        public static UnityEvent OnScreenClosed = new UnityEvent();

        private RectTransform screenRect;

        protected void Awake()
        {
            screenRect = GetComponent<RectTransform> ();
            if(activateSafeArea) ApplySafeArea();
        }

        public override void Show()
        {
            ActivateGlobalUIElements();
            gameObject.SetActive(true);
            OnScreenShown.Invoke();
        }
        
        public override void Hide()
        {
            DeactivateGlobalUIElements();
            gameObject.SetActive(false);
            OnScreenHiden.Invoke();
        }

        public override void Open()
        {
            ActivateGlobalUIElements();
            gameObject.SetActive(true);
            OnScreenOpen.Invoke();
        }
        public override void Close()
        {
            gameObject.SetActive(false);
            DeactivateGlobalUIElements();
            OnScreenClosed.Invoke();
        }

        private void ActivateGlobalUIElements()
        {
            overlayElements.ForEach(x => x.SetActive(true));
        }
        private void DeactivateGlobalUIElements()
        {
            overlayElements.ForEach(x => x.SetActive(false));
        }

        private void ApplySafeArea ()
        {
            Rect safeArea = Screen.safeArea;
            
            // Convert safe area rectangle from absolute pixels to normalised anchor coordinates
            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;
            screenRect.anchorMin = anchorMin;
            screenRect.anchorMax = anchorMax;
            
            //Debug.Log("Safe area set");
        }
    }

}

