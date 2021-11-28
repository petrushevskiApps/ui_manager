using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PetrushevskiApps.UIManager
{
    public class UIButton : Button
    {
        protected override void OnDestroy()
        {
            onClick.RemoveAllListeners();
            base.OnDestroy();
        }

    }
}