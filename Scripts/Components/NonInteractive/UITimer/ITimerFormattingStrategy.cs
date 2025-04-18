namespace Plugins.UIManager.Scripts.Components.NonInteractive.UITimer
{
    public interface ITimerFormattingStrategy
    {
        string GetFormattedTimer(int minutes, int seconds);
    }
}