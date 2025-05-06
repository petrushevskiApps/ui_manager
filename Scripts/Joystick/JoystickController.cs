using System;
using slowBulletGames.MemoryValley;
using SlowBulletGames.UI;
using UnityEngine;
using Zenject;

namespace UI
{
    public class JoystickController: MonoBehaviour
    {
        [SerializeField]
        private CustomFloatingJoystick _joystick;
        [SerializeField]
        private GameObject _joystickVisual;
        [SerializeField]
        private GameObject _tutorialHand;
        
        private IUILevelStateEvents _levelStateEvents;

        [Inject]
        public void Initialize(IUILevelStateEvents levelStateEvents)
        {
            _levelStateEvents = levelStateEvents;
        }

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