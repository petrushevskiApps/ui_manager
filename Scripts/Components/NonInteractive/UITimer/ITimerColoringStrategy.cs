using UnityEngine;

namespace TwoOneTwoGames.UIManager.Components.NonInteractive
{
    public interface ITimerColoringStrategy
    {
        Color GetTimerLabelColor(int minutes, int seconds);
    }
}