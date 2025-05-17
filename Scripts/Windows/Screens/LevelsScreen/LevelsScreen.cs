using System;
using System.Collections.Generic;
using MenuManager.Scripts.Components.NonInteractive.Extensions;
using PetrushevskiApps.UIManager.ScreenNavigation.Screens.LevelsScreen;
using slowBulletGames.MemoryValley;
using TinyRiftGames.UIManager.Scripts.InfiniteScrollList;
using TMPro;
using UnityEngine;
using Zenject;

public class LevelsScreen : UIScreen, IListDataSource
{
    [SerializeField] 
    private TextMeshProUGUI _title;
    [SerializeField]
    private InfiniteScrollController _infiniteScrollController;
    
    // Injected
    protected ILevelsScreenViewModel ViewModel;
    private IItemViewPool _itemViewPool;
    private IUiHapticsController _uiHapticsController;

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
    
    public void SetItemViewData(IItemView rowView)
    {
        if (rowView.Index >= ViewModel.Levels.Count)
        {
            return;
        }
        var item = rowView.View.GetComponent<LevelItemView>();

        item.SetData(
            _uiHapticsController,
            ViewModel.Levels[rowView.Index],
            ViewModel.OnLevelClicked);
    }
}
