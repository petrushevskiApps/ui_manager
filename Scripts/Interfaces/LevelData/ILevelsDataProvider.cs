using System.Collections.Generic;

namespace TwoOneTwoGames.UIManager.Interfaces
{
    public interface ILevelsDataProvider
    {
        List<IUILevelData> GetLevels(int page, int pageSize);
        IUILevelData GetLastUnlockedLevel();
    }
}