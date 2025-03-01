using MenuManager.Scripts.Components.NonInteractive;
using MenuManager.Scripts.Utilitis;

namespace slowBulletGames.MemoryValley
{
    public interface IInGameScreenViewModel: IBackButtonHandler
    {
        IReactiveProperty<string> LevelTitle { get; }
        IReactiveProperty<UIProgressBarData> ProgressBarData { get; }
        void PauseClicked();
    }
}