using System;
using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.JoystickController;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Joystick
{
    public class JoystickController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _joystickVisual;

        [SerializeField]
        private GameObject _tutorialHand;

        [SerializeField]
        private CustomFloatingJoystick _joystick;

        private IUILevelStateEvents _levelStateEvents;

        private void Awake()
        {
            _levelStateEvents.LevelLoadedEvent += OnLevelLoaded;
            _levelStateEvents.LevelRevivedEvent += OnLevelRevived;
            _levelStateEvents.LevelFinishedEvent += OnLevelFinished;
            ShowTutorial(true);
        }

        private void OnEnable()
        {
            _joystick.ClickedEvent += OnJoystickClicked;
        }

        private void OnDisable()
        {
            _joystick.ClickedEvent -= OnJoystickClicked;
        }

        [Inject]
        public void Initialize(IUILevelStateEvents levelStateEvents)
        {
            _levelStateEvents = levelStateEvents;
        }

        private void OnJoystickClicked(object sender, EventArgs e)
        {
            ShowTutorial(false);
        }

        private void OnLevelRevived(object sender, EventArgs e)
        {
            gameObject.SetActive(true);
        }

        private void OnLevelFinished(object sender, EventArgs e)
        {
            gameObject.SetActive(false);
        }

        private void OnLevelLoaded(object sender, EventArgs e)
        {
            ShowTutorial(true);
        }

        private void ShowTutorial(bool isShowTutorial)
        {
            gameObject.SetActive(true);
            _tutorialHand.SetActive(isShowTutorial);
            _joystickVisual.gameObject.SetActive(!isShowTutorial);
        }
    }
}