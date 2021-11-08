using UnityEngine;

[CreateAssetMenu(menuName = "Data/PopupSoundConfiguration", fileName = "Popup Sound Config")]
public class PopupSoundConfiguration : ScriptableObject
{
    [SerializeField] private AudioClip popupShown;
    [SerializeField] private AudioClip popupHidden;

    public AudioClip PopupShown => popupShown;
    public AudioClip PopupHidden => popupHidden;
}