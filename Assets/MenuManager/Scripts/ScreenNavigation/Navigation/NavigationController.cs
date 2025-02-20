using System;
using System.Collections.Generic;

public class NavigationController : INavigationController
{
    private readonly IScreenProvider _screenProvider;

    private readonly Stack<IScreen> _backStack = new Stack<IScreen>();

    private bool IsBackStackEmpty => _backStack.Count == 0;

    public NavigationController(IScreenProvider screenProvider)
    {
        _screenProvider = screenProvider;
    }
    
    public void ShowScreen<T, TArguments>(TArguments navArguments) where T : IScreen
    {
        IScreen screen = _screenProvider.GetScreen<T>();

        if (screen != null)
        {
            HideCurrentScreen();
            
            if (_backStack.Contains(screen))
            {
                ClearStackToScreen(screen);
                screen.Resume();
            }
            else
            {
                _backStack.Push(screen);
                screen.Show(navArguments);
            }
            
        }
        else
        {
            throw new Exception($"Screen of type {typeof(T)} not found in screens list!");
        }
    }

    public void GoBack()
    {
        if (_backStack.Count > 1)
        {
            _backStack.Pop().Close();
            _backStack.Peek().Resume();
        }
    }

    private void HideCurrentScreen()
    {
        if (IsBackStackEmpty)
        {
            return;
        }
        
        if (_backStack.Peek().IsBackStackable)
        {
            _backStack.Peek().Hide();
        }
        else
        {
            _backStack.Pop().Close();
        }
    }

    private void ClearStackToScreen(IScreen screen)
    {
        while (!IsBackStackEmpty)
        {
            if (!_backStack.Peek().Equals(screen))
            {
                _backStack.Pop().Close();
            }
            else break;
        }
    }
}
