﻿using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.Data;
using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class LevelFailedScreenViewModel : ILevelFailedScreenViewModel
    {
        // Reactive Properties
        public IReactiveProperty<UIButtonViewData> ReviveButton { get; }
        public IReactiveProperty<UIButtonViewData> ReplayButton { get; }
        public IReactiveProperty<UIButtonViewData> HomeButton { get; }
        public IReactiveProperty<UIButtonViewData> SettingsButton { get; }
        
        // Internal
        private bool _isSfxPlayed;
        
        // Injected
        private readonly IScreenNavigation _screenNavigation;
        private readonly IUiAudioPalette _uiAudioPalette;
        private readonly IUILevelController _uiLevelController;
        private readonly IBackgroundMusicAudioPalette _musicAudioPalette;
        private readonly IPopupNavigation _popupNavigation;
        private readonly IUiSoundSystem _uiSoundSystem;

        public LevelFailedScreenViewModel(
            IScreenNavigation screenNavigation,
            IPopupNavigation popupNavigation,
            IUILevelController uiLevelController,
            IBackgroundMusicAudioPalette musicAudioPalette,
            IUiAudioPalette uiAudioPalette,
            IUiSoundSystem uiSoundSystem)
        {
            _screenNavigation = screenNavigation;
            _popupNavigation = popupNavigation;
            _uiLevelController = uiLevelController;
            _musicAudioPalette = musicAudioPalette;
            _uiAudioPalette = uiAudioPalette;
            _uiSoundSystem = uiSoundSystem;
            
            ReviveButton = new ReactiveProperty<UIButtonViewData>(new UIButtonViewData(
                clickAction: ReviveButtonClicked));
            ReplayButton = new ReactiveProperty<UIButtonViewData>(new UIButtonViewData(
                clickAction: ReplayButtonClicked));
            HomeButton = new ReactiveProperty<UIButtonViewData>(new UIButtonViewData(
                clickAction: HomeButtonClicked));
            SettingsButton = new ReactiveProperty<UIButtonViewData>(new UIButtonViewData(
                clickAction: SettingsClicked));
        }

        public virtual void OnBackTriggered()
        {
            GoToMainScreen();
        }

        public void ScreenShown()
        {
            _uiSoundSystem.PlayBackgroundMusic(_musicAudioPalette.MainScreenBackgroundMusic);
            if (!_isSfxPlayed)
            {
                _uiSoundSystem.PlayUiSoundEffect(_uiAudioPalette.LevelFailedBackgroundMusic);
                _isSfxPlayed = true;
            }
        }

        public void ScreenHidden()
        {
            _uiSoundSystem.StopBackgroundMusic();
        }

        public void ScreenClosed()
        {
            _isSfxPlayed = false;
        }

        protected virtual void HomeButtonClicked()
        {
            GoToMainScreen();
        }

        protected virtual void ReplayButtonClicked()
        {
            _uiLevelController.RestartLevel();
        }

        protected virtual void ReviveButtonClicked()
        {
            _uiLevelController.ReviveAndContinueLevel();
        }

        protected void SettingsClicked()
        {
            _popupNavigation.ShowSettingsPopup();
        }

        private void GoToMainScreen()
        {
            _uiLevelController.LeaveLevel();
            _screenNavigation.ShowMainScreen();
        }
    }
}