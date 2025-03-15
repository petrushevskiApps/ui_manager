namespace slowBulletGames.MemoryValley
{
    public interface IUILevelControlled
    {
        void StartNextLevel();
        void RestartLevel();
        void ReviveAndContinueLevel();
        void CollectReward();
        void CollectDoubleReward();
    }
}