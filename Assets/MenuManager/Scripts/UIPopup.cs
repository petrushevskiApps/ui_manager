using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.petrushevskiapps.menumanager
{
    public abstract class UIPopup : UIWindow
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


