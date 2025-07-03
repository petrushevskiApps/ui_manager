using TwoOneTwoGames.UIManager.ScreenNavigation;
using TwoOneTwoGames.UIManager.Utilities.ReactiveProperty;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class LevelsScreenViewModel : ILevelsScreenViewModel
    {
        // Reactive Properties
        public IReactiveProperty<string> Title { get; }

        // Injected
        private readonly IScreenNavigation _screenNavigation;

        public LevelsScreenViewModel(IScreenNavigation screenNavigation)
        {
            _screenNavigation = screenNavigation;

            Title = new ReactiveProperty<string>("Levels");
        }
        public void ScreenResumed()
        {
        }
    
        public void OnBackTriggered()
        {
            _screenNavigation.NavigateBack();
        }
    }
}