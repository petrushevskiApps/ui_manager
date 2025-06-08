using System;
using TMPro;
using TwoOneTwoGames.UIManager.Components.NonInteractive;
using TwoOneTwoGames.UIManager.InfiniteScrollList;
using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.Windows
{
    public class LevelsScreen : UIScreen, IListDataSource
    {
        [SerializeField]
        private TextMeshProUGUI _title;

        [SerializeField]
        private InfiniteScrollController _infiniteScrollController;

        private IItemViewPool _itemViewPool;
        private IUiHapticsController _uiHapticsController;

        // Injected
        protected ILevelsScreenViewModel ViewModel;

        public void SetItemViewData(IItemView rowView)
        {
            if (rowView.Index >= ViewModel.Levels.Count) return;
            var item = rowView.View.GetComponent<LevelItemView>();

            item.SetData(
                _uiHapticsController,
                ViewModel.Levels[rowView.Index],
                ViewModel.OnLevelClicked);
        }

        [Inject]
        private void Initialize(
            ILevelsScreenViewModel viewModel,
            IItemViewPool itemViewPool,
            IUiHapticsController uiHapticsController)
        {
            _uiHapticsController = uiHapticsController;
            ViewModel = viewModel;
            _itemViewPool = itemViewPool;
        }

        public override void Resume()
        {
            base.Resume();

            _infiniteScrollController.ListEndEvent += OnListEndEvent;
            _infiniteScrollController.Setup(this, _itemViewPool);

            ViewModel.PageLoadedEvent += OnLevelsPageReady;
            ViewModel.Title.Subscribe(_title.SetData);

            ViewModel.ScreenResumed();
            ViewModel.LoadNextPage();
        }

        public override void Hide()
        {
            base.Hide();

            _infiniteScrollController.ListEndEvent -= OnListEndEvent;
            ViewModel.PageLoadedEvent -= OnLevelsPageReady;
            ViewModel.Title.Unsubscribe(_title.SetData);
            _infiniteScrollController.Clear();
        }

        private void OnListEndEvent(object sender, EventArgs e)
        {
            ViewModel.LoadNextPage();
        }

        private void OnLevelsPageReady(object sender, PageLoadedEventArguments args)
        {
            _infiniteScrollController.AddPageAndScrollTo(args.ElementsInPage, args.IndexOfLastCompletedLevel);
        }

        public override void OnBackTriggered()
        {
            ViewModel.OnBackTriggered();
        }
    }
}