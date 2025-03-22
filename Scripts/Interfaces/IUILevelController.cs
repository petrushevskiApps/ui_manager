namespace slowBulletGames.MemoryValley
{
    public interface IUILevelController
    {
        void StartLevel();
        void RestartLevel();
        void ReviveAndContinueLevel();
        void CollectReward();
        void CollectDoubleReward();
    }
}