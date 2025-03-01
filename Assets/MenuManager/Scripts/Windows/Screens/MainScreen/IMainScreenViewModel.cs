namespace slowBulletGames.MemoryValley
{
    public interface IMainScreenViewModel: IBackButtonHandler
    {
        void SettingsClicked();
        void StartLevelClicked();
    }
}