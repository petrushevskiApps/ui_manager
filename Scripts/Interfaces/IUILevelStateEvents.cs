using System;

namespace slowBulletGames.MemoryValley
{
    public interface IUILevelStateEvents
    {
        event EventHandler LevelLoadedEvent;
        event EventHandler LevelRevivedEvent;
        event EventHandler LevelFinishedEvent;
    }
}