using UnityEngine;

namespace MenuManager.Scripts.Components.NonInteractive
{
    public interface IUIObjectPresenter
    {
        void LoadObject(GameObject prefab);
        void UnloadObject();
        void ToggleActivity(bool isActive);
    }
}