using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all Screens used with Unity.
/// </summary>
public abstract class BaseScreen : MonoBehaviour, IScreen
{
    [SerializeField]
    [Tooltip("True: Screen goes on backstack when hidden. False: One time screen.")]
    private bool _isBackStackable = true;

    [SerializeField]
    [Tooltip("List of all the Global UI Elements to be shown or hidden when this screen is active")]
    private List<GlobalUiElement> _globalUiElements;

    private INavigationController _navigationController;

    public bool IsBackStackable => _isBackStackable;

    // [Inject]
    private void SetNavigationController(INavigationController navigationController)
    {
        _navigationController = navigationController;
    }

    public virtual void Show<TArguments>(TArguments navArguments)
    {
        Resume();
    }

    public virtual void Resume()
    {
        gameObject.SetActive(true);
        ToggleGlobalUIElementsState(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
        ToggleGlobalUIElementsState(false);
    }

    public virtual void Close()
    {
        Hide();
    }

    protected virtual void OnBackButton()
    {
        _navigationController.GoBack();
    }

    private void ToggleGlobalUIElementsState(bool isToggled)
    {
        _globalUiElements.ForEach(x => x.SetElement(isToggled));
    }
}
