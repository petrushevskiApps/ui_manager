
namespace com.petrushevskiapps.menumanager
{
    public abstract class UIScreen : UIWindow
    {
        public override void Show()
        {
            gameObject.SetActive(true);
        }
        
        public override void Hide()
        {
            gameObject.SetActive(false);
        }

        public override void Open()
        {
            gameObject.SetActive(true);
        }
        public override void Close()
        {
            gameObject.SetActive(false);
        }
    }

}

