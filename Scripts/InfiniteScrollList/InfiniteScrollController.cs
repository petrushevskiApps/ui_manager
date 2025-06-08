using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TwoOneTwoGames.UIManager.InfiniteScrollList
{
    public class InfiniteScrollController : MonoBehaviour
    {
        [SerializeField]
        private InfiniteScrollList _scrollList;

        [SerializeField]
        private GameObject _headerPrefab;

        [SerializeField]
        private GameObject _listItemPrefab;

        [SerializeField]
        private Transform _listItemsParent;

        private readonly SortedDictionary<int, IItemView> _itemViews = new();

        private float _headerHeight;
        private float _itemHeight;
        private IItemViewPool _itemViewPool;
        private IListDataSource _listDataSource;
        public IScrollableList ScrollableList => _scrollList;

        private void Awake()
        {
            _itemHeight = _listItemPrefab.GetComponent<RectTransform>().rect.height;
            if (_headerPrefab != null) _headerHeight = _headerPrefab.GetComponent<RectTransform>().rect.height;
            SetPrefabAnchors();

            _scrollList.RowVisibleEvent += OnRowVisible;
            _scrollList.RowHiddenEvent += OnRowHidden;
            _scrollList.RowsVisibilityUpdatedEvent += OnRowsVisibilityUpdated;
            _scrollList.OnListEndEvent += OnListEndEvent;
        }

        private void Start()
        {
            _scrollList.Initialize(_headerHeight, _itemHeight);
        }

        private void OnDestroy()
        {
            _scrollList.RowVisibleEvent -= OnRowVisible;
            _scrollList.RowHiddenEvent -= OnRowHidden;
            _scrollList.RowsVisibilityUpdatedEvent -= OnRowsVisibilityUpdated;
            _scrollList.OnListEndEvent -= OnListEndEvent;
        }

        public event EventHandler<IItemView> ScrollPageCompleted;
        public event EventHandler ListViewsReadyEvent;
        public event EventHandler ListEndEvent;

        private void OnListEndEvent(object sender, EventArgs e)
        {
            ListEndEvent?.Invoke(sender, e);
        }

        public void Setup(
            IListDataSource listDataSource,
            IItemViewPool itemViewPool)
        {
            _listDataSource = listDataSource;
            _itemViewPool = itemViewPool;
            _itemViewPool.SetPrefab(_listItemPrefab);
        }

        private void OnRowVisible(object sender, ListRow row)
        {
            if (_itemViews.ContainsKey(row.Index)) return;
            var itemView = _itemViewPool.Spawn(_listItemsParent);
            SetPositionOnItemView(itemView.View, row.Position);
            _itemViews.Add(row.Index, itemView);

            itemView.Index = row.Index;
            _listDataSource.SetItemViewData(itemView);
        }

        private void OnRowHidden(object sender, ListRow row)
        {
            if (!_itemViews.ContainsKey(row.Index)) return;
            _itemViewPool.Despawn(_itemViews[row.Index].View);
            _itemViews.Remove(row.Index);
        }

        private void OnRowsVisibilityUpdated(object sender, EventArgs e)
        {
            ListViewsReadyEvent?.Invoke(this, EventArgs.Empty);
        }

        public void AddPage(int elementsCount)
        {
            _scrollList.AddRows(elementsCount);
        }

        public void AddPageAndScrollTo(int elementsCount, int elementIndex)
        {
            _scrollList.AddRows(elementsCount, elementIndex);
        }

        private void SetPositionOnItemView(GameObject itemView, float verticalPosition)
        {
            var rectTransform = itemView.GetComponent<RectTransform>();
            Vector3 itemPosition = rectTransform.anchoredPosition;
            itemPosition = new Vector3(itemPosition.x, verticalPosition, itemPosition.z);
            rectTransform.anchoredPosition = itemPosition;
        }

        private void SetPrefabAnchors()
        {
            var rectTransform = _listItemPrefab.GetComponent<RectTransform>();
            // rectTransform.anchorMin = new Vector2(0, 1);
            // rectTransform.anchorMax = new Vector2(1, 1);
            // rectTransform.pivot = new Vector2(0, 0.5f);
            rectTransform.anchorMin = new Vector2(0.5f, 1);
            rectTransform.anchorMax = new Vector2(0.5f, 1);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
        }

        public void Clear()
        {
            _itemViews.Clear();
            _itemViewPool.Clear();
            _scrollList.ClearList();
        }

        public List<IItemView> GetActiveItemViews()
        {
            return _itemViews.Values.ToList();
        }

        public IItemView GetFirstFullyVisibleItemView()
        {
            IEnumerable<IItemView> activeViews = GetActiveItemViews();
            return activeViews.FirstOrDefault(
                view => _scrollList.IsViewFullyVisible(view.View.GetComponent<RectTransform>()));
        }

        public IItemView GetLastFullyVisibleItemView()
        {
            IEnumerable<IItemView> activeViews = GetActiveItemViews();
            return activeViews.LastOrDefault(
                view => _scrollList.IsViewFullyVisible(view.View.GetComponent<RectTransform>()));
        }

        private IItemView GetLastVisibleItemView()
        {
            IEnumerable<IItemView> activeViews = GetActiveItemViews();
            return activeViews.LastOrDefault(
                view => _scrollList.IsRowVisible(view.Index));
        }

        public IEnumerable<GameObject> GetActiveViews()
        {
            return GetActiveItemViews()
                .Select(item => item.View)
                .ToList();
        }

        public void ScrollPageDown()
        {
            if (_scrollList.IsScrolledToBottom) return;
            ScrollableList.ScrollingCompletedEvent += OnPageScrollingCompleted;
            var index = GetFirstFullyVisibleItemView().Index;
            ScrollableList.ToElement(index + GetVisiblePageElementsCount());
        }

        public void ScrollPageUp()
        {
            if (_scrollList.IsScrolledToTop) return;
            ScrollableList.ScrollingCompletedEvent += OnPageScrollingCompleted;
            var index = GetFirstFullyVisibleItemView().Index;
            ScrollableList.ToElement(index - GetVisiblePageElementsCount());
        }

        private void OnPageScrollingCompleted(object sender, EventArgs e)
        {
            ScrollableList.ScrollingCompletedEvent -= OnPageScrollingCompleted;
            ScrollPageCompleted?.Invoke(this, GetFirstFullyVisibleItemView());
        }

        private int GetVisiblePageElementsCount()
        {
            var visibilityOfLastElement = _scrollList.RowsInView % 1;
            var fullyVisibleElementsCount = (int) _scrollList.RowsInView;
            if (visibilityOfLastElement >= 0.9f) fullyVisibleElementsCount++;
            return fullyVisibleElementsCount;
        }
    }
}