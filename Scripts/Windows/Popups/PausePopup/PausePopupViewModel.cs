﻿using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.Components.NonInteractive.NonInteractive.ViewData;
using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class PausePopupViewModel : IPausePopupViewModel
    {
        
        // Reactive Properties
        public IReactiveProperty<string> Title { get; protected set; }
        public IReactiveProperty<string> Message { get; protected set; }
        public IReactiveProperty<UIButtonViewData> RestartButton { get; }
        public IReactiveProperty<UIButtonViewData> HomeButton { get; }
        public IReactiveProperty<UIButtonViewData> PlayButton { get; }
        public IReactiveProperty<UIButtonViewData> SettingsButton { get; }
        
        // Injected
        private readonly IPopupNavigation _popupNavigation;
        private readonly IUILevelController _uiLevelController;
        private readonly INavigationController _navigationController;

        public PausePopupViewModel(
            IPopupNavigation popupNavigation,
            INavigationController navigationController,
            IUILevelController uiLevelController)
        {
            _popupNavigation = popupNavigation;
            _navigationController = navigationController;
            _uiLevelController = uiLevelController;


            Title = new ReactiveProperty<string>("Pause");
            Message = new ReactiveProperty<string>();
            
            RestartButton = new ReactiveProperty<UIButtonViewData>(new UIButtonViewData(
                clickAction: RestartClicked));
            HomeButton = new ReactiveProperty<UIButtonViewData>(new UIButtonViewData(
                clickAction: HomeClicked));
            PlayButton = new ReactiveProperty<UIButtonViewData>(new UIButtonViewData(
                label: new TextViewData(true, "Resume"),
                clickAction: PlayClicked));
            SettingsButton = new ReactiveProperty<UIButtonViewData>(new UIButtonViewData(
                clickAction: SettingsClicked));
        }

        protected virtual void RestartClicked()
        {
            _uiLevelController.RestartLevel();
        }

        protected virtual void HomeClicked()
        {
            _popupNavigation.ShowExitLevelPopup();
        }

        protected virtual void PlayClicked()
        {
            _navigationController.GoBack();
        }

        protected virtual void SettingsClicked()
        {
            _popupNavigation.ShowSettingsPopup();
        }

        public void BackgroundClicked()
        {
            _navigationController.GoBack();
        }
    }
}