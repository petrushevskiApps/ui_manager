namespace TwoOneTwoGames.UIManager.Components.NonInteractive
{
    public interface ITimerFormattingStrategy
    {
        string GetFormattedTimer(int minutes, int seconds);
    }
}