using PetrushevskiApps.UIManager.ScreenNavigation.Navigation;

namespace slowBulletGames.MemoryValley
{
    public class LevelFailedScreenViewModel : ILevelFailedScreenViewModel
    {
        // Injected
        private readonly IScreenNavigation _screenNavigation;
        private readonly IPopupNavigation _popupNavigation;
        private readonly IUILevelController _uiLevelController;
        private readonly IBackgroundMusicAudioPalette _musicAudioPalette;
        private readonly IUiSoundSystem _uiSoundSystem;

        public LevelFailedScreenViewModel(
            IScreenNavigation screenNavigation,
            IPopupNavigation popupNavigation,
            IUILevelController uiLevelController,
            IBackgroundMusicAudioPalette musicAudioPalette,
            IUiSoundSystem uiSoundSystem) 
        {
            _screenNavigation = screenNavigation;
            _popupNavigation = popupNavigation;
            _uiLevelController = uiLevelController;
            _musicAudioPalette = musicAudioPalette;
            _uiSoundSystem = uiSoundSystem;
        }
        
        public virtual void OnBackTriggered()
        {
            _screenNavigation.ShowMainScreen();
        }

        public void ScreenShown()
        {
            _uiSoundSystem.PlayBackgroundMusic(_musicAudioPalette.LevelFailedBackgroundMusic);
        }

        public void ScreenHidden()
        {
            _uiSoundSystem.StopBackgroundMusic();
        }

        public virtual void HomeButtonClicked()
        {
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