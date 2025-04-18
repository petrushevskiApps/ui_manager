using UnityEngine;

namespace Plugins.UIManager.Scripts.Components.NonInteractive.UITimer
{
    public interface ITimerColoringStrategy
    {
        Color GetTimerLabelColor(int minutes, int seconds);
    }
}