using UnityEngine;

[CreateAssetMenu(
    menuName = "Data/Popup Sound Configuration", 
    fileName = "PopupSoundConfiguration")]
public class PopupSoundConfiguration : ScriptableObject, IPopupSoundConfiguration
{
    [field: SerializeField]
    public AudioClip PopupShown { get; private set; }

    [field: SerializeField]
    public AudioClip PopupHidden { get; private set; }
}