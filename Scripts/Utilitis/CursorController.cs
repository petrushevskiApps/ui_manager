using PrimeTween;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public float pressedScale = 0.8f;
    public float tweenDuration = 0.1f;

    private Vector3 originalScale;

    private RectTransform _cursorImage;

    private void Awake()
    {
        _cursorImage = GetComponent<RectTransform>();
    }
    
    void Start()
    {
        originalScale = _cursorImage.localScale;
    }

    void Update()
    {
        _cursorImage.position = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            Tween.Scale(_cursorImage, originalScale * pressedScale, tweenDuration, Ease.OutQuad);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Tween.Scale(_cursorImage, originalScale, tweenDuration, Ease.OutQuad);
        }
    }
}
