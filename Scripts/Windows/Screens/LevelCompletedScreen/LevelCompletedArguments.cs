namespace slowBulletGames.MemoryValley
{
    public struct LevelCompletedArguments
    {
        public int EarnedCoins { get; private set; }

        public LevelCompletedArguments(int earnedCoins)
        {
            EarnedCoins = earnedCoins;
        }
    }
}