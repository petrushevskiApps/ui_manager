using System;
using System.Collections.Generic;
using MenuManager.Scripts.Utilitis;
using slowBulletGames.MemoryValley;

public interface ILevelsScreenViewModel
{
    public event EventHandler<PageLoadedEventArguments> PageLoadedEvent;
    IReactiveProperty<string> Title { get; }
    public List<IUILevelData> Levels { get; }
    public void ScreenResumed();
    void OnBackTriggered();
    void LoadNextPage();
    void OnLevelClicked(int funnelId, int levelId);
}
