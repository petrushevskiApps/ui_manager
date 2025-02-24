using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ScreenProvider : MonoBehaviour, IScreenProvider
{
    [SerializeField]
    [Tooltip("List of screens to be provided to Navigation Controller")]
    private List<UIScreen> _screens = new();

    [Inject]
    private INavigationController _navigationController;
    
    public IScreen GetScreen<T>() where T : IScreen
    {
        return _screens.Find(x => x.GetType() == typeof(T));
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _navigationController.GoBack();
        }
    }
}