namespace slowBulletGames.MemoryValley
{
    public struct LevelCompletedArguments
    {
        public int EarnedCoins { get; private set; }
        public int EarnedStars { get; }

        public LevelCompletedArguments(int earnedCoins, int earnedStars)
        {
            EarnedCoins = earnedCoins;
            EarnedStars = earnedStars;
        }
    }
}