using TMPro;
using TwoOneTwoGames.UIManager.Components.NonInteractive;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class LevelsScreen : UIScreen
    {
        [SerializeField]
        private TextMeshProUGUI _title;

        // Injected
        protected ILevelsScreenViewModel ViewModel;

        [Inject]
        private void Initialize(ILevelsScreenViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override void Resume()
        {
            base.Resume();

            if (_title != null)
            {
                ViewModel.Title.Subscribe(_title.SetData);
            }

            ViewModel.ScreenResumed();
        }

        public override void Hide()
        {
            base.Hide();

            if (_title != null)
            {
                ViewModel.Title.Unsubscribe(_title.SetData);
            }
        }

        public override void OnBackTriggered()
        {
            ViewModel.OnBackTriggered();
        }
    }
}