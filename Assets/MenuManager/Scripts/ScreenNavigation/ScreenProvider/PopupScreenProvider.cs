using System;
using System.Collections.Generic;
using PetrushevskiApps.UIManager;
using slowBulletGames.MemoryValley;
using UnityEngine;
using Zenject;

public class PopupScreenProvider : MonoBehaviour, IScreenProvider
{
    [SerializeField]
    [Tooltip("List of screens to be provided to Navigation Controller")]
    private List<UIPopup> _popups = new();
    [Inject]
    private INavigationController _navigationController;
    
    private void Awake()
    {
        _navigationController.AllScreensClosedEvent += OnAllScreensClosed;
    }

    private void OnDestroy()
    {
        _navigationController.AllScreensClosedEvent -= OnAllScreensClosed;
    }

    private void OnAllScreensClosed(object sender, EventArgs e)
    {
        _navigationController.ShowPopup<ExitGamePopup>();
    }

    public IScreen GetScreen<T>() where T : IScreen
    {
        return _popups.Find(x => x.GetType() == typeof(T));
    }
}