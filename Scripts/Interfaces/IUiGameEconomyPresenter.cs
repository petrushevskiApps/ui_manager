using System;

namespace TwoOneTwoGames.UIManager.Interfaces
{
    public interface IUiGameEconomyPresenter
    {
        event EventHandler<(int, float)> EarnedResourceEvent;
    }
}