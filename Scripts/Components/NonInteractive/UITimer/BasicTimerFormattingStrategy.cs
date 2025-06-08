using System.Text;

namespace TwoOneTwoGames.UIManager.Components.NonInteractive
{
    public class BasicTimerFormattingStrategy : ITimerFormattingStrategy
    {
        public string GetFormattedTimer(int minutes, int seconds)
        {
            var sb = new StringBuilder();

            sb.Append(minutes > 9 ? $"{minutes}" : $"0{minutes}");
            sb.Append(":");
            sb.Append(seconds > 9 ? $"{seconds}" : $"0{seconds}");
            return sb.ToString();
        }
    }
}