using UnityEngine;

namespace TwoOneTwoGames.UIManager.Components.Interactive
{
    public interface IInteractableSoundConfig
    {
        AudioClip PositiveSound { get; }
        AudioClip NegativeSound { get; }
    }
}