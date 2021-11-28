using UnityEngine;

[CreateAssetMenu(menuName = "Data/InteractableSoundConfig", fileName = "InteractableSoundConfig")]
public class InteractableSoundConfig : ScriptableObject
{
    public AudioClip positiveSound;
    public AudioClip negativeSound;
}
