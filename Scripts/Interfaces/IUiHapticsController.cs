namespace TwoOneTwoGames.UIManager.Interfaces
{
    public interface IUiHapticsController
    {
        void ButtonClick();
        void LevelCompleted();
        void LevelFailed();
        void Toggle(bool toggleNewState);
    }
}