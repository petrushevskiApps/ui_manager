using UnityEngine;

namespace TwoOneTwoGames.UIManager.Components.NonInteractive
{
    public interface IUIObjectPresenter
    {
        void LoadObject(GameObject prefab);
        void UnloadObject();
        void ToggleActivity(bool isActive);
    }
}