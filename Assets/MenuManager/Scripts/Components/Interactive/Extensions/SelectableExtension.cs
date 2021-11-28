using UnityEngine;
using UnityEngine.UI;

namespace PetrushevskiApps.UIManager
{
    public abstract class SelectableExtension : MonoBehaviour
    {
        protected Selectable selectable;

        protected void Awake()
        {
            selectable = GetComponent<Selectable>();
        }

    }
}