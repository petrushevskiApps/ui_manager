using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsStateController : ISettingsStateProvider, ISettingsStateUpdater
{
    public bool IsSoundEffectsActive { get; private set; } = true;
    public bool IsMusicActive { get; private set; } = true;
    public bool IsVibrationsActive { get; private set; } = true;
    
    public void UpdateSoundEffectsState(bool state)
    {
        IsSoundEffectsActive = state;
    }

    public void UpdateGameMusicState(bool state)
    {
        IsMusicActive = state;
    }

    public void UpdateVibrationsState(bool state)
    {
        IsVibrationsActive = state;
    }
}
