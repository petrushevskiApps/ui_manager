using MenuManager.Scripts.Utilitis;

namespace slowBulletGames.MemoryValley
{
    public class ExitGamePopupViewModel : IExitGamePopupViewModel
    {
        public IReactiveProperty<string> Title { get; }
        public IReactiveProperty<string> Message { get; }
        
        public void BackgroundClicked()
        {
            throw new System.NotImplementedException();
        }

        public void DiscardPopupClicked()
        {
            throw new System.NotImplementedException();
        }

        public void ExitApp()
        {
            throw new System.NotImplementedException();
        }
    }
}