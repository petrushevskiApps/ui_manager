using System;
using System.Collections.Generic;
using ModestTree;
using Zenject;

public class NavigationController : INavigationController
{
    public event EventHandler AllScreensClosedEvent;

    private readonly IScreenProvider _screenProvider;

    private readonly IScreenProvider _popupScreenProvider;

    private readonly Stack<IScreen> _screenBackStack = new();

    public NavigationController(
        [Inject(Id = "Screen")]IScreenProvider screenProvider,
        [Inject(Id = "PopupScreen")]IScreenProvider popupScreenProvider)
    {
        _screenProvider = screenProvider;
        _popupScreenProvider = popupScreenProvider;
    }

    public void ShowScreen<T, TArguments>(TArguments navArguments) where T : IScreen
    {
        Show<T, TArguments>(_screenProvider, navArguments);
    }

    public void ShowScreen<T>() where T : IScreen
    {
        ShowScreen<T, NavigationArguments>(new NavigationArguments());
    }

    public void ShowPopup<T>() where T : IScreen
    {
        ShowPopup<T, NavigationArguments>(new NavigationArguments());
    }

    public void ShowPopup<T, TArguments>(TArguments navArguments) where T : IScreen
    {
        Show<T, TArguments>(_popupScreenProvider, navArguments);
    }

    public void GoBack()
    {
        if (!_screenBackStack.IsEmpty())
        {
            _screenBackStack.Pop().Close();
            if (!_screenBackStack.IsEmpty())
            {
                _screenBackStack.Peek().Resume();
            }
            else
            {
                AllScreensClosedEvent?.Invoke(this, EventArgs.Empty);
            }
        }
        else
        {
            AllScreensClosedEvent?.Invoke(this, EventArgs.Empty);
        }
    }

    public IBackHandler GetActiveBackHandler()
    {
        if (!_screenBackStack.IsEmpty())
        {
            return _screenBackStack.Peek();
        }

        return null;
    }

    private void Show<T, TArguments>(
        IScreenProvider screenProvider,
        TArguments navArguments) where T : IScreen
    {
        IScreen screen = screenProvider.GetScreen<T>();

        if (screen != null)
        {
            if (!_screenBackStack.IsEmpty() && !(screen.IsPopup ^ _screenBackStack.Peek().IsPopup))
            {
                HideCurrentScreenIn(_screenBackStack);
            }
            
            if (_screenBackStack.Contains(screen))
            {
                ClearStackToScreen(_screenBackStack, screen);
                screen.Resume();
            }
            else
            {
                _screenBackStack.Push(screen);
                screen.Show(navArguments);
            }
        }
        else
        {
            throw new Exception($"Screen of type {typeof(T)} not found in screens list!");
        }
    }
    private void HideCurrentScreenIn(Stack<IScreen> stack)
    {
        if (stack.Count == 0)
        {
            return;
        }
        
        if (stack.Peek().IsBackStackable)
        {
            stack.Peek().Hide();
        }
        else
        {
            stack.Pop().Close();
        }
    }
    
    private void ClearStackToScreen(Stack<IScreen> stack, IScreen screen)
    {
        while (!stack.IsEmpty())
        {
            if (!stack.Peek().Equals(screen))
            {
                stack.Pop().Close();
            }
            else break;
        }
    }
}