using MenuManager.Scripts.Components.NonInteractive;
using MenuManager.Scripts.Utilitis;

namespace slowBulletGames.MemoryValley
{
    public interface IInGameScreenViewModel
    {
        IReactiveProperty<string> LevelTitle { get; }
        IReactiveProperty<UIProgressBarData> ProgressBarData { get; }
        void PauseClicked();
        void OnBackTriggered();
    }
}