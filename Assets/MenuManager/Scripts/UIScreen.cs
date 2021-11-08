
using UnityEngine.Events;

namespace com.petrushevskiapps.menumanager
{
    public abstract class UIScreen : UIWindow
    {
        public static UnityEvent OnScreenShown = new UnityEvent();
        public static UnityEvent OnScreenHiden = new UnityEvent();
        public static UnityEvent OnScreenOpen = new UnityEvent();
        public static UnityEvent OnScreenClosed = new UnityEvent();
        
        public override void Show()
        {
            gameObject.SetActive(true);
            OnScreenShown.Invoke();
        }
        
        public override void Hide()
        {
            gameObject.SetActive(false);
            OnScreenHiden.Invoke();
        }

        public override void Open()
        {
            gameObject.SetActive(true);
            OnScreenOpen.Invoke();
        }
        public override void Close()
        {
            gameObject.SetActive(false);
            OnScreenClosed.Invoke();
        }
    }

}

