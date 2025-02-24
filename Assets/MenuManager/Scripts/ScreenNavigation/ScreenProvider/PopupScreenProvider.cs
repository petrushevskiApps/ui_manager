using System.Collections.Generic;
using PetrushevskiApps.UIManager;
using UnityEngine;

public class PopupScreenProvider : MonoBehaviour, IScreenProvider
{
    [SerializeField]
    [Tooltip("List of screens to be provided to Navigation Controller")]
    private List<UIPopup> _popups = new();

    public IScreen GetScreen<T>() where T : IScreen
    {
        return _popups.Find(x => x.GetType() == typeof(T));
    }
}