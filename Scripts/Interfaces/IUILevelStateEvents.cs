using System;

namespace TwoOneTwoGames.UIManager.Interfaces
{
    public interface IUILevelStateEvents
    {
        event EventHandler LevelLoadedEvent;
        event EventHandler LevelRevivedEvent;
        event EventHandler LevelFinishedEvent;
    }
}