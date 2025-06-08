using UnityEngine.EventSystems;

namespace TwoOneTwoGames.UIManager.Plugins.JoystickPlugin
{
    public class FloatingJoystick : Joystick
    {
        protected override void Start()
        {
            base.Start();
            background.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            background.gameObject.SetActive(false);
            Reset();
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            background.gameObject.SetActive(true);
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            background.gameObject.SetActive(false);
            base.OnPointerUp(eventData);
        }
    }
}