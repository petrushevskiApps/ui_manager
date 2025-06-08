namespace TwoOneTwoGames.UIManager.Interfaces
{
    public interface IUILevelData
    {
        public int Id { get; }
        public int FunnelId { get; }
        public int Stars { get; }
        public bool IsUnlocked { get; }
        public bool IsCompleted { get; }
    }
}