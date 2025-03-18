using MenuManager.Scripts.Utilitis;

namespace slowBulletGames.MemoryValley
{
    public interface IPopupViewModel
    {
        IReactiveProperty<string> Title { get; }
        IReactiveProperty<string> Message { get; }
        void BackgroundClicked();
    }
}