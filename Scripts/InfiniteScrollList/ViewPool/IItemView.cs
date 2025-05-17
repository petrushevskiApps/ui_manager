using UnityEngine;

namespace TinyRiftGames.UIManager.Scripts.InfiniteScrollList
{
    public interface IItemView
    {
        public int Index { get; set; }
        public GameObject View { get; }
    }
}