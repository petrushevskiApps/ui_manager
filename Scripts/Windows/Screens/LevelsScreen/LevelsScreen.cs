using System;
using TMPro;
using TwoOneTwoGames.UIManager.Components.NonInteractive;
using TwoOneTwoGames.UIManager.InfiniteScrollList;
using TwoOneTwoGames.UIManager.Interfaces;
using TwoOneTwoGames.UIManager.ScreenNavigation;
using TwoOneTwoGames.UIManager.Utilities.Extensions;
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

        // Internal
        private int _columnCount = 1;

        // Injected
        protected ILevelsScreenViewModel ViewModel;
        private IItemViewPool _itemViewPool;
        private IUiHapticsController _uiHapticsController;

        public void SetItemViewData(IItemView rowView)
        {
            var row = rowView.View.GetComponent<ListRowView>();
            _columnCount = row.ColumnCount;

            row.SetData(
                _uiHapticsController,
                ViewModel.OnLevelClicked,
                ViewModel.Levels.SafeGetRange(rowView.Index * row.ColumnCount, row.ColumnCount).ToArray());
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
            _infiniteScrollController.AddPageAndScrollTo(
                Mathf.CeilToInt((float) args.ElementsInPage / _columnCount),
                args.IndexOfLastCompletedLevel);
        }

        public override void OnBackTriggered()
        {
            ViewModel.OnBackTriggered();
        }
    }
}