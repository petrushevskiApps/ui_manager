using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.Data;
using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class MainScreenViewModel : IMainScreenViewModel
    {
        // Reactive Properties
        public IReactiveProperty<UIButtonViewData> PlayButton { get; }
        
        // Injected
        private readonly IScreenNavigation _screenNavigation;
        private readonly IPopupNavigation _popupNavigation;
        private readonly IUILevelController _uiLevelController;
        private readonly IBackgroundMusicAudioPalette _musicAudioPalette;
        private readonly IUiSoundSystem _uiSoundSystem;

        public MainScreenViewModel(
            IPopupNavigation popupNavigation,
            IUILevelController uiLevelController,
            IBackgroundMusicAudioPalette musicAudioPalette,
            IUiSoundSystem uiSoundSystem)
        {
            _popupNavigation = popupNavigation;
            _uiLevelController = uiLevelController;
            _musicAudioPalette = musicAudioPalette;
            _uiSoundSystem = uiSoundSystem;
            
            PlayButton = new ReactiveProperty<UIButtonViewData>(new UIButtonViewData()
            {
                IsVisible = false,
                IsInteractive = true
            });
        }

        public void ScreenResumed()
        {
            _uiLevelController.LevelReadyEvent += OnLevelReady;
            
            _uiSoundSystem.PlayBackgroundMusic(_musicAudioPalette.MainScreenBackgroundMusic);
            _uiLevelController.SetLastUnlockedLevel();
        }
        public void ScreenHidden()
        {
            _uiLevelController.LevelReadyEvent -= OnLevelReady;
        }
        
        private void OnLevelReady(object sender, string levelTitle)
        {
            PlayButton.Value = new UIButtonViewData()
            {
                Label = $"Play Level {levelTitle}",
                IsVisible = true,
                IsInteractive = true
            };
        }
        
        public void LevelsButtonClicked()
        {
            _screenNavigation.ShowLevelsScreen();
        }
        
        public virtual void SettingsClicked()
        {
            _popupNavigation.ShowSettingsPopup();
        }

        public virtual void StartLevelClicked()
        {
            _uiLevelController.StartLevel();
        }

        public virtual void OnBackTriggered()
        {
            _popupNavigation.ShowExitGamePopup();
        }
    }
}