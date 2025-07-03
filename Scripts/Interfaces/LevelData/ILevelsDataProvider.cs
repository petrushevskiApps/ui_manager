using System;
using System.Collections.Generic;

namespace TwoOneTwoGames.UIManager.Interfaces
{
    public interface ILevelsDataProvider
    {
        List<IUILevelData> GetLevels(int page = 0, int pageSize = int.MaxValue);
        IUILevelData GetLastUnlockedLevel();
    }
}