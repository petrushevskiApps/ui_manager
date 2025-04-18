using System.Text;

namespace Plugins.UIManager.Scripts.Components.NonInteractive.UITimer
{
    public class BasicTimerFormattingStrategy : ITimerFormattingStrategy
    {
        public string GetFormattedTimer(int minutes, int seconds)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(minutes > 9 ? $"{minutes}" : $"0{minutes}");
            sb.Append(":");
            sb.Append(seconds > 9 ? $"{seconds}" : $"0{seconds}");
            return sb.ToString();
        }
    }
}