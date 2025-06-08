using UnityEngine;

namespace TwoOneTwoGames.UIManager.Components.NonInteractive
{
    public class BasicTimerColoringStrategy : ITimerColoringStrategy
    {
        public Color GetTimerLabelColor(int minutes, int seconds)
        {
            if (minutes == 0 && seconds <= 15) return Color.red;
            if (minutes == 0 && seconds <= 30) return Color.yellow;

            return Color.white;
        }
    }
}