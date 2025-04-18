using UnityEngine;

namespace Plugins.UIManager.Scripts.Components.NonInteractive.UITimer
{
    public class BasicTimerColoringStrategy : ITimerColoringStrategy
    {
        public Color GetTimerLabelColor(int minutes, int seconds)
        {
            if (minutes == 0 && seconds <= 10)
            {
                return Color.red;
            }
            if (minutes == 0 && seconds <= 30)
            {
                return Color.yellow;
            }

            return Color.white;
        }
    }
}