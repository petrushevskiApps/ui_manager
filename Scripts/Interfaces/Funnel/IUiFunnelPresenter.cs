
using System;
using UnityEngine;

namespace TwoOneTwoGames.UIManager.Interfaces
{
    public interface IUiFunnelPresenter
    {
        event EventHandler FunnelLoadedEvent;
        event EventHandler<int> FunnelUnlockedEvent;
        string GetCurrentFunnelTitle();
        int GetIndexOfLastCompletedLevel();
        int GetLevelsCount();
        bool IsLastFunnel();
        bool IsLockedFunnel();
        bool IsFirstFunnel();
        Texture GetFirstPuzzleTexture();
        int GetFunnelCost();
        Texture GetLastCompletedPuzzleTexture();
    }
}