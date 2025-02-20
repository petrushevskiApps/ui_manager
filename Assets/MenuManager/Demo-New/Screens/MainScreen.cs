using System;
using UnityEngine;
using Zenject;

namespace MenuManager.Demo_New.Screens
{
    public class MainScreen: BaseScreen
    {
        private INavigationController _navigationController;
        
        [Inject]
        public void Initialize(
            INavigationController navigationController)
        {
            _navigationController = navigationController;
        }
        
        public override void Show<T>(T navArguments)
        {
            if (navArguments is ScreenTestArguments)
            {
                
            }
            base.Show(navArguments);
            Debug.Log("T");
        }

        private void OnEnable()
        {
            _navigationController.ShowScreen<GameScreen, GameScreenArguments>(new GameScreenArguments()
            {
                Message = "This is invoked by the Main Screen."
            });
        }
    }

    public class ScreenTestArguments
    {
        public string TestMessage { get; set; }
    }
}