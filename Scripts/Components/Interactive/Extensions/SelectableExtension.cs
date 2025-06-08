using UnityEngine;
using UnityEngine.UI;

namespace TwoOneTwoGames.UIManager.Components.Interactive
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