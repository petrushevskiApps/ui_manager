namespace slowBulletGames.MemoryValley
{
    public interface IUILevelController
    {
        void StartNextLevel();
        void RestartLevel();
        void ReviveAndContinueLevel();
        void CollectReward();
        void CollectDoubleReward();
    }
}