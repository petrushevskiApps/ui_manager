namespace TinyRiftGames.UIManager.Scripts.InfiniteScrollList
{
    public struct ListRow
    {
        public int Index { get; private set; }
        public float Position { get; }

        public ListRow(int index, float position)
        {
            Index = index;
            Position = position;
        }
    }
}