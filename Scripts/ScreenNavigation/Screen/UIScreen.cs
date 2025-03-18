using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Base class for all Screens used with Unity.
/// </summary>
public abstract class UIScreen : MonoBehaviour, IScreen, IScreenEvents
{
    [SerializeField]
    private bool _activateSafeArea = true;

    [SerializeField]
    [Tooltip("True: Screen goes on backstack when hidden. False: One time screen.")]
    private bool _isBackStackable = true;

    [SerializeField]
    [Tooltip("List of all the Global UI Elements to be shown or hidden when this screen is active")]
    private List<GlobalUiElement> _globalUiElements;

    public bool IsPopup => false;
    public bool IsBackStackable => _isBackStackable;

    // Events
    public event EventHandler ScreenShownEvent;
    public event EventHandler ScreenResumedEvent;
    public event EventHandler ScreenHiddenEvent;
    public event EventHandler ScreenClosedEvent;
    
    // Injected
    protected INavigationController NavigationController;

    // Internal
    private RectTransform _screenRect;

    [Inject]
    private void SetNavigationController(INavigationController navigationController)
    {
        NavigationController = navigationController;
    }

    protected void Awake()
    {
        _screenRect = GetComponent<RectTransform>();
        if (_activateSafeArea) ApplySafeArea();
    }
    public virtual void Show<TArguments>(TArguments navArguments)
    {
        ScreenShownEvent?.Invoke(this, EventArgs.Empty);
        Resume();
    }

    public virtual void Resume()
    {
        ScreenResumedEvent?.Invoke(this, EventArgs.Empty);
        gameObject.SetActive(true);
        ToggleGlobalUIElementsState(true);
    }

    public virtual void Hide()
    {
        ScreenHiddenEvent?.Invoke(this, EventArgs.Empty);
        gameObject.SetActive(false);
        ToggleGlobalUIElementsState(false);
    }

    public virtual void Close()
    {
        ScreenClosedEvent?.Invoke(this, EventArgs.Empty);
        Hide();
    }

    private void ToggleGlobalUIElementsState(bool isToggled)
    {
        _globalUiElements.ForEach(x => x.SetElement(isToggled));
    }

    private void ApplySafeArea()
    {
        Rect safeArea = Screen.safeArea;

        // Convert safe area rectangle from absolute pixels to normalised anchor coordinates
        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;
        _screenRect.anchorMin = anchorMin;
        _screenRect.anchorMax = anchorMax;
    }

    public virtual void OnBackTriggered()
    {
        NavigationController.GoBack();
    }
}