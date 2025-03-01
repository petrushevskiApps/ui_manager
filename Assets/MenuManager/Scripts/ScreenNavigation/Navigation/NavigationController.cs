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

    private readonly Stack<IScreen> _popupBackStack = new();

    public NavigationController(
        [Inject(Id = "Screen")]IScreenProvider screenProvider,
        [Inject(Id = "PopupScreen")]IScreenProvider popupScreenProvider)
    {
        _screenProvider = screenProvider;
        _popupScreenProvider = popupScreenProvider;
    }

    public void ShowScreen<T, TArguments>(TArguments navArguments) where T : IScreen
    {
        Show<T, TArguments>(_screenProvider, _screenBackStack, navArguments);
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
        Show<T, TArguments>(_popupScreenProvider, _popupBackStack, navArguments);
    }

    public void GoBack()
    {
        if (!_popupBackStack.IsEmpty())
        {
            _popupBackStack.Pop().Close();
            _popupBackStack.Peek().Resume();
        }
        else if (!_screenBackStack.IsEmpty())
        {
            _screenBackStack.Pop().Close();
            _screenBackStack.Peek().Resume();
        }
        else
        {
            AllScreensClosedEvent?.Invoke(this, EventArgs.Empty);
        }
    }

    public bool IsPopupShown()
    {
        return !_popupBackStack.IsEmpty();
    }
    
    private void Show<T, TArguments>(
        IScreenProvider screenProvider, 
        Stack<IScreen> stack,
        TArguments navArguments) where T : IScreen
    {
        IScreen screen = screenProvider.GetScreen<T>();

        if (screen != null)
        {
            HideCurrentScreenIn(stack);
            
            if (stack.Contains(screen))
            {
                ClearStackToScreen(stack, screen);
                screen.Resume();
            }
            else
            {
                stack.Push(screen);
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

public class NavigationArguments
{
    
}
