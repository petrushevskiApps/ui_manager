using System;
using UnityEngine;
using UnityEngine.Events;

namespace PetrushevskiApps.UIManager
{
    public class BackButton : MonoBehaviour
    {
        [SerializeField] private UnityEvent Execute = new UnityEvent();

        private UIButton backButton;
        
        private void Awake()
        {
            backButton = gameObject.GetComponent<UIButton>();

            if (backButton != null)
            {
                backButton.onClick.AddListener(OnClick);
            }
            else Debug.LogError("UIManager:: BackButton:: UIButton not found !!");
        }

        private void OnClick()
        {
            if (Execute.GetPersistentEventCount() > 0)
            {
                Execute.Invoke();
            }
            else
            {
                UIManager.Instance.OnBack();
            }
        }
    }
}

