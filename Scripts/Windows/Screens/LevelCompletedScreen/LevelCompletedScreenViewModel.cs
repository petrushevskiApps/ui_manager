using TwoOneTwoGames.UIManager.Components.Interactive;
using TwoOneTwoGames.UIManager.Data;
using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class LevelCompletedScreenViewModel : ILevelCompletedScreenViewModel
    {
        // Reactive Properties
        public IReactiveProperty<int> EarnedStars { get; private set; }
        public IReactiveProperty<string> Title { get; }
        public IReactiveProperty<string> EarnedCoinsText { get; private set; }
        public IReactiveProperty<UIButtonViewData> ReplayButton { get; }
        public IReactiveProperty<UIButtonViewData> HomeButton { get; }
        public IReactiveProperty<UIButtonViewData> SettingsButton { get; }
        public IReactiveProperty<UIButtonViewData> NextButton { get; }
        public IReactiveProperty<UIButtonViewData> DoubleRewardButton { get; }

        // Injected
        private readonly IScreenNavigation _screenNavigation;
        private readonly IUiAudioPalette _uiAudioPalette;
        private readonly IUILevelController _uiLevelController;
        private readonly IUiSoundSystem _uiSoundSystem;
        private readonly IBackgroundMusicAudioPalette _musicAudioPalette;
        private readonly IPopupNavigation _popupNavigation;

        // Internal
        private bool _isSfxPlayed;
        protected int EarnedPoints { get; private set; }
        
        public LevelCompletedScreenViewModel(
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

            Title = new ReactiveProperty<string>("Level Completed");
            EarnedStars = new ReactiveProperty<int>();
            EarnedCoinsText = new ReactiveProperty<string>();
            
            ReplayButton = new ReactiveProperty<UIButtonViewData>(new UIButtonViewData(
                clickAction: ReplayButtonClicked));
            HomeButton = new ReactiveProperty<UIButtonViewData>(new UIButtonViewData(
                clickAction: HomeButtonClicked));
            SettingsButton = new ReactiveProperty<UIButtonViewData>(new UIButtonViewData(
                clickAction: SettingsButtonClicked));
            NextButton = new ReactiveProperty<UIButtonViewData>(new UIButtonViewData(
                clickAction: NextLevelButtonClicked));
            DoubleRewardButton = new ReactiveProperty<UIButtonViewData>(new UIButtonViewData(
                clickAction: DoubleRewardButtonClicked));
        }
        
        public virtual void ScreenResumed()
        {
            EarnedStars = new ReactiveProperty<int>();
            EarnedCoinsText = new ReactiveProperty<string>();

            if (!_isSfxPlayed)
            {
                _uiSoundSystem.PlayUiSoundEffect(_uiAudioPalette.LevelCompletedBackgroundMusic);
                _isSfxPlayed = true;
            }

            _uiSoundSystem.PlayBackgroundMusic(_musicAudioPalette.MainScreenBackgroundMusic);
        }

        public virtual void ScreenHidden()
        {
            _uiSoundSystem.StopBackgroundMusic();
        }

        public void ScreenClosed()
        {
            _isSfxPlayed = false;
        }

        public void OnBackTriggered()
        {
            _uiLevelController.CollectReward();
            _screenNavigation.ShowMainScreen();
        }

        public virtual void SetEarnedPoints(int points)
        {
            EarnedPoints = points;
        }

        public virtual void SetEarnedStars(int earnedStars)
        {
            EarnedStars.Value = earnedStars;
        }

        protected virtual void NextLevelButtonClicked()
        {
            _uiLevelController.CollectReward();
            _uiLevelController.StartNextLevel();
        }

        protected virtual void DoubleRewardButtonClicked()
        {
            _uiLevelController.CollectDoubleReward();
            _uiLevelController.StartNextLevel();
        }

        protected virtual void ReplayButtonClicked()
        {
            _uiLevelController.RestartLevel();
        }

        protected virtual void HomeButtonClicked()
        {
            _uiLevelController.CollectReward();
            _screenNavigation.ShowMainScreen();
        }

        protected virtual void SettingsButtonClicked()
        {
            _popupNavigation.ShowSettingsPopup();
        }
    }
}