namespace TwoOneTwoGames.UIManager.Windows
{
    public struct LevelCompletedArguments
    {
        public int EarnedCoins { get; }
        public int EarnedStars { get; }

        public LevelCompletedArguments(int earnedCoins, int earnedStars)
        {
            EarnedCoins = earnedCoins;
            EarnedStars = earnedStars;
        }
    }
}