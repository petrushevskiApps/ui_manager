using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.petrushevskiapps.menumanager
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private List<UIScreen> screens = new List<UIScreen>();
        [SerializeField] private List<UIPopup> popups = new List<UIPopup>();

        private readonly Stack<UIWindow> backStack = new Stack<UIWindow>();

        public static MenuManager Instance;
        protected void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            OpenWindow(screens[0]);
            InitializeAllWindows();
        }

        private void InitializeAllWindows()
        {
            screens.ForEach(screen => screen.Initialize(()=>OnBack(CloseApplication)));
            popups.ForEach(screen => screen.Initialize(()=>OnBack()));
        }
        
        public void OpenScreen<T>() where T : UIScreen
        {
            UIScreen screen = screens.Find(x => x.GetType() == typeof(T));
            OpenWindow(screen);
        }
        
        public void OpenPopup<T>() where T : UIPopup
        {
            UIPopup popup = popups.Find(x => x.GetType() == typeof(T));
            OpenWindow(popup);
        }
        
        private void OpenWindow<T>(T window) where T : UIWindow
        {
            // Hide current active window if of same base type
            if (backStack.Count > 0 && backStack.Peek().GetType().BaseType == typeof(T))
            {
                backStack.Peek().Hide();
            }
            
            if(backStack.Contains(window))
            {
                ClearStackToScreen(window);
            }
            else
            {
                backStack.Push(window);
            }
            
            if(window != null) window.Open();
        }
        
        private void OnBack(Action onEmptyStack = null)
        {
            if (backStack.Count > 1)
            {
                backStack.Pop().Close();
                backStack.Peek().Show();    
            }
            else onEmptyStack?.Invoke();
        }
        
        private void ClearStackToScreen(UIWindow screen)
        {
            while(backStack.Count > 0)
            {
                if (!backStack.Peek().Equals(screen))
                {
                    backStack.Pop().Close();
                }
                else break;
            }
        }

        private void CloseApplication()
        {
            Application.Quit();
        }

    }
}
