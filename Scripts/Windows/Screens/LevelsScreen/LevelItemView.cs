using System;
using slowBulletGames.MemoryValley;
using TinyRiftGames.UIManager.Scripts.InfiniteScrollList;
using UnityEngine;
using UnityEngine.UI;

namespace PetrushevskiApps.UIManager.ScreenNavigation.Screens.LevelsScreen
{
    public class LevelItemView : MonoBehaviour, IItemView
    {
        [SerializeField]
        private UIStars _stars;
        [SerializeField]
        private UIButton _button;
        [SerializeField]
        private Image _background;
        [SerializeField]
        private GameObject _lockIcon;

        [Header("Backgrounds")]
        [SerializeField]
        private Sprite _lockedBackground;
        [SerializeField]
        private Sprite _unlockedBackground;
        [SerializeField]
        private Sprite _completedBackground;

        public int Index { get; set; }
        public GameObject View => gameObject;

        private Action<int, int> _onItemClicked;
        private IUILevelData _levelData;

        private void OnEnable()
        {
            _button.OnClick.AddListener(OnButtonClicked);
        }

        public void SetData(
            IUiHapticsController uiHapticsController, 
            IUILevelData levelData,
            Action<int, int> onItemClicked)
        {
            _levelData = levelData;
            
            gameObject.name = $"Level-{_levelData.Id + 1}";
            _onItemClicked = onItemClicked;
            _button.SetHaptics(uiHapticsController);
            SetState();
        }

        private void SetState()
        {
            int visualLevelId = _levelData.Id + 1;
            if (_levelData.IsCompleted)
            {
                _background.sprite = _completedBackground;
                _lockIcon.SetActive(false);
                _button.SetData(new UIButtonViewData()
                {
                    IsVisible = true,
                    Label = visualLevelId.ToString(),
                    IsInteractive = true
                });
                _stars.SetData(_levelData.Stars);
            }
            else if (_levelData.IsUnlocked)
            {
                _background.sprite = _unlockedBackground;
                _lockIcon.SetActive(false);
                _button.SetData(new UIButtonViewData()
                {
                    IsVisible = true,
                    Label = visualLevelId.ToString(),
                    IsInteractive = true
                });
                _stars.SetData(_levelData.Stars);
            }
            else
            {
                _background.sprite = _lockedBackground;
                _lockIcon.SetActive(true);
                _button.SetData(new UIButtonViewData()
                {
                    IsVisible = true,
                    Label = null,
                    IsInteractive = false
                });
                _stars.gameObject.SetActive(false);
            }
        }
        private void OnButtonClicked()
        {
            _onItemClicked?.Invoke(_levelData.FunnelId, _levelData.Id);
        }
    }
}