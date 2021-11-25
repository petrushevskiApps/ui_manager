using System;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif
using UnityEngine;

namespace PetrushevskiApps.UIManager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private bool dontDestroyOnLoad = false;

        [Header("Special Windows")]
        [SerializeField] private UIScreen MainScreen;
        [SerializeField] private UIPopup ExitPopup;

        [Header("Game Windows")]
        [SerializeField] private List<UIScreen> screens = new List<UIScreen>();
        [SerializeField] private List<UIPopup> popups = new List<UIPopup>();

        private Stack<UIWindow> backStack = new Stack<UIWindow>();

        public IConnected IConnected { get; private set; }
        public ISoundSystem ISoundSystem { get; private set; }

        public static UIManager Instance;
        

        protected void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                if (dontDestroyOnLoad)
                {
                    DontDestroyOnLoad(gameObject);
                }

                Setup();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Setup()
        {
            IConnected = GetComponent<IConnected>();
            ISoundSystem = GetComponent<ISoundSystem>();
        }

        private void OnEnable()
        {
            OpenWindow(MainScreen);
            InitializeAllWindows();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
               backStack.Peek().OnBackButtonPressed();
            }
        }
        private void InitializeAllWindows()
        {
            screens.ForEach(screen => screen.Initialize(()=>OnBack(ShowExitPopup)));
            popups.ForEach(popup => popup.Initialize(()=>OnBack()));
        }

        public void OpenScreen<T>() where T : UIScreen
        {
            UIScreen screen = screens.Find(x => x.GetType() == typeof(T));
            if(screen != null) OpenWindow(screen);
        }
        
        public T OpenPopup<T>() where T : UIPopup
        {
            UIPopup popup = popups.Find(x => x.GetType() == typeof(T));
            if (popup != null) OpenWindow(popup);
            return (T) popup;
        }

        public void ClosePopup<T>(T popup) where T : UIPopup
        {
            if (backStack.Count > 0)
            {
                if (backStack.Peek().Equals(popup))
                {
                    backStack.Pop();
                    backStack.Peek().Show();
                }
            }
        }

        private void OpenWindow<T>(T newWindow) where T : UIWindow
        {
            // Hide current active window if of same base type
            if (backStack.Count > 0 && backStack.Peek().GetType().BaseType == typeof(T))
            {
                UIWindow currentWindow = backStack.Peek();
                
                if (!currentWindow.IsBackStackable)
                {
                    backStack.Pop().Hide();
                }
                else currentWindow.Hide();
            }
            
            if(backStack.Contains(newWindow))
            {
                ClearStackToScreen(newWindow);
            }
            else
            {
                backStack.Push(newWindow);
            }
            
            if(newWindow != null) newWindow.Open();
        }
        
        public void OnBack(Action onEmptyStack = null)
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

        public bool IsPopupOpen()
        {
            return backStack.Peek().GetType().BaseType == typeof(UIPopup);
        }

        private void ShowExitPopup()
        {
            OpenWindow(ExitPopup);
        }

        public void CloseApplication()
        {
            Application.Quit();
            Debug.Log("Closing App");
        }

    }
}
