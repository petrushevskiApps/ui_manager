using UnityEngine;

[CreateAssetMenu(
    menuName = "Data/Interactable Sound Configuration", 
    fileName = "InteractableSoundConfig")]
public class InteractableSoundConfig : ScriptableObject, IInteractableSoundConfig
{
    [field: SerializeField]
    public AudioClip PositiveSound { get; private set; }
    [field: SerializeField]
    public AudioClip NegativeSound { get; private set; }
}