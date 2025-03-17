public interface ISettingsStateUpdater
{
    public void UpdateSoundEffectsState(bool state);
    public void UpdateGameMusicState(bool state);
    public void UpdateVibrationsState(bool state);
}