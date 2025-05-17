using System.Collections.Generic;

namespace slowBulletGames.MemoryValley
{
    public interface ILevelsDataProvider
    {
        List<IUILevelData> GetLevels(int page, int pageSize);
        IUILevelData GetLastUnlockedLevel();
    }
}