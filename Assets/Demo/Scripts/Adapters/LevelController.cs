using slowBulletGames.MemoryValley;
using UnityEngine;

namespace MenuManager.Scripts.Adapters
{
    public class LevelController: IUILevelControlled
    {
        public void StartNextLevel()
        {
            Debug.Log("StartNextLevel");
        }

        public void RestartLevel()
        {
            Debug.Log("RestartLevel");
        }

        public void ReviveAndContinueLevel()
        {
            Debug.Log("ReviveAndContinueLevel");
        }

        public void CollectReward()
        {
            Debug.Log("CollectReward");
        }

        public void CollectDoubleReward()
        {
            Debug.Log("CollectDoubleReward");
        }
    }
}