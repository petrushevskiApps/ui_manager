namespace TwoOneTwoGames.UIManager.Windows
{
    public struct LevelCompletedArguments
    {
        public int EarnedPoints { get; }
        public int EarnedStars { get; }

        public LevelCompletedArguments(int earnedPoints, int earnedStars)
        {
            EarnedPoints = earnedPoints;
            EarnedStars = earnedStars;
        }
    }
}