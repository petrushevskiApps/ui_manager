using UnityEngine;
using UnityEngine.EventSystems;

namespace PetrushevskiApps.UIManager
{
    public class ButtonSound : ButtonExtension, IPointerDownHandler
    {
        [SerializeField] protected ButtonSoundConfig soundConfig;

        public void OnPointerDown(PointerEventData eventData)
        {
            AudioClip soundEffect;

            if (GetComponent<UIButton>().interactable)
            {
                soundEffect = soundConfig.positiveSound;
            }
            else
            {
                soundEffect = soundConfig.negativeSound;
            }

            UIManager.Instance.SoundSystem.PlaySoundEffect(soundEffect);
        }
    }
}