using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TwoOneTwoGames.UIManager.JoystickController
{
    public class CustomFloatingJoystick : Plugins.JoystickPlugin.Joystick
    {
        private Vector3 _originalJoystickPosition;
        public event EventHandler ClickedEvent;

        private void Awake()
        {
            _originalJoystickPosition = background.anchoredPosition;
        }

        private void OnEnable()
        {
            background.anchoredPosition = _originalJoystickPosition;
        }

        private void OnDisable()
        {
            Reset();
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            background.localPosition = ScreenPointToAnchoredPosition(eventData.position);
            ClickedEvent?.Invoke(this, EventArgs.Empty);
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            background.anchoredPosition = _originalJoystickPosition;
            base.OnPointerUp(eventData);
        }
    }
}