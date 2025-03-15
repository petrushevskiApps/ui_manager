namespace slowBulletGames.MemoryValley
{
    public interface ILevelFailedScreenViewModel: IBackButtonHandler
    {
        void HomeButtonClicked();
        void ReplayButtonClicked();
        void ReviveButtonClicked();
    }
}