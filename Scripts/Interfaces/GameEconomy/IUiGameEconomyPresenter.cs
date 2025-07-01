using System;

namespace TwoOneTwoGames.UIManager.Interfaces
{
    public interface IUiGameEconomyPresenter
    {
        event EventHandler<(int, float)> EarnedResourceEvent;
        int GetResourceValueWithId(int id);
        event EventHandler<(int, float)> UsedResourceEvent;
    }
}