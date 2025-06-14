using UnityEngine;

namespace TwoOneTwoGames.UIManager.InfiniteScrollList
{
    public interface IItemViewPool
    {
        void SetPrefab(GameObject prefab, int poolSize = 1);
        public IItemView Spawn(Transform parent, bool activateOnSpawn = true);
        public void Despawn(GameObject item);
        void Clear();
    }
}