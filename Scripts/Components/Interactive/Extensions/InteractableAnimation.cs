using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TwoOneTwoGames.UIManager.Components.Interactive
{
    public class InteractableAnimation : SelectableExtension, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField]
        private InteractableAnimationConfig _animationConfig;

        private Vector3 _defaultScale = Vector3.one;

        // Internal
        private RectTransform _rectTransform;
        private Coroutine _scaleDownCoroutine;

        protected new void Awake()
        {
            base.Awake();
            _rectTransform = GetComponent<RectTransform>();
            _defaultScale = _rectTransform.localScale;
        }

        protected void OnDisable()
        {
            ResetScale();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _scaleDownCoroutine ??= StartCoroutine(Scale(_animationConfig.Scale));
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ResetScale();
        }

        private void ResetScale()
        {
            if (_scaleDownCoroutine != null)
            {
                StopCoroutine(_scaleDownCoroutine);
                _scaleDownCoroutine = null;
            }

            _rectTransform.localScale = _defaultScale;
        }

        private IEnumerator Scale(Vector3 newScale)
        {
            var lScale = _rectTransform.localScale;

            while (Vector3.Distance(lScale, newScale) >= 0.01f)
            {
                lScale = Vector3.Lerp(lScale, newScale, Time.unscaledDeltaTime * _animationConfig.ScaleSpeed);
                _rectTransform.localScale = lScale;
                yield return new WaitForSeconds(Time.deltaTime);
            }

            // Smooth out the values of rect scale
            _rectTransform.localScale = newScale;
        }
    }
}