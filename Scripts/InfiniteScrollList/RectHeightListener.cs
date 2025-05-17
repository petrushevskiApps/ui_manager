using System;
using UnityEngine;

namespace TinyRiftGames.UIManager.Scripts.InfiniteScrollList
{
    public class RectHeightListener : MonoBehaviour
    {
        public event EventHandler<float> HeightUpdatedEvent;

        private RectTransform _rectTransform;
        private float _previousHeight;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void OnRectTransformDimensionsChange()
        {
            if (_rectTransform == null || !(Math.Abs(_rectTransform.rect.height - _previousHeight) > 0.000001f))
            {
                return;
            }
            _previousHeight = _rectTransform.rect.height;
            HeightUpdatedEvent?.Invoke(this, _previousHeight);
        }
    }
}