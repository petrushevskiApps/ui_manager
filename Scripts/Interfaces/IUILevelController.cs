namespace slowBulletGames.MemoryValley
{
    public interface IUILevelController
    {
        void StartLevel(int funnelId, int levelId);
        void StartLevel();
        void RestartLevel();
        void ReviveAndContinueLevel();
        void CollectReward();
        void CollectDoubleReward();
        void LeaveLevel();
    }
}