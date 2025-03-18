public interface ISettingsStateProvider
{
    public bool IsSoundEffectsActive { get; }
    public bool IsMusicActive { get; }
    public bool IsVibrationsActive { get; }
}