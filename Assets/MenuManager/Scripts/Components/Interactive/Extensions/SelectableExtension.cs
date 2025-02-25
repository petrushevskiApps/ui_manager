using UnityEngine;
using UnityEngine.UI;

namespace PetrushevskiApps.UIManager
{
    public abstract class SelectableExtension : MonoBehaviour
    {
        protected Selectable Selectable;

        protected void Awake()
        {
            Selectable = GetComponent<Selectable>();
        }

    }
}