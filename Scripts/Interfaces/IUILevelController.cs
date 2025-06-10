using System;

namespace TwoOneTwoGames.UIManager.Interfaces
{
    public interface IUILevelController
    {
        event EventHandler<string> LevelReadyEvent;
        void StartLevel(int funnelId, int levelId);
        void StartLevel();
        void RestartLevel();
        void ReviveAndContinueLevel();
        void CollectReward();
        void CollectDoubleReward();
        void LeaveLevel();
        void StartNextLevel();
        void SetLastUnlockedLevel();
        event EventHandler<string> LevelStartedEvent;
    }
}