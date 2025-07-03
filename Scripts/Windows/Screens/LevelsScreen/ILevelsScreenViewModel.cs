using System;
using System.Collections.Generic;
using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    public interface ILevelsScreenViewModel
    {
        IReactiveProperty<string> Title { get; }
        public void ScreenResumed();
        void OnBackTriggered();
    }
}