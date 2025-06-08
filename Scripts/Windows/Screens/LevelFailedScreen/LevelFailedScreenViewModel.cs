using TwoOneTwoGames.UIManager.Data;
using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.ScreenNavigation;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class LevelFailedScreenViewModel : ILevelFailedScreenViewModel
    {
        private readonly IBackgroundMusicAudioPalette _musicAudioPalette;
        private readonly IPopupNavigation _popupNavigation;

        // Injected
        private readonly IScreenNavigation _screenNavigation;
        private readonly IUiAudioPalette _uiAudioPalette;
        private readonly IUILevelController _uiLevelController;

        private readonly IUiSoundSystem _uiSoundSystem;

        // Internal
        private bool _isSfxPlayed;

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
        }

        public virtual void OnBackTriggered()
        {
            _screenNavigation.ShowMainScreen();
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

        public virtual void HomeButtonClicked()
        {
            _uiLevelController.LeaveLevel();
            _screenNavigation.ShowMainScreen();
        }

        public virtual void ReplayButtonClicked()
        {
            _uiLevelController.RestartLevel();
        }

        public virtual void ReviveButtonClicked()
        {
            _uiLevelController.ReviveAndContinueLevel();
        }

        public void SettingsClicked()
        {
            _popupNavigation.ShowSettingsPopup();
        }
    }
}