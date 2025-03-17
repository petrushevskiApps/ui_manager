using System;
using System.Collections;
using System.Collections.Generic;
using slowBulletGames.MemoryValley;
using UnityEngine;
using Zenject;

public class DemoApp : MonoBehaviour
{
    private INavigationController _navigationController;

    [Inject]
    public void Initialize(INavigationController navigationController)
    {
        _navigationController = navigationController;
    }

    private void Start()
    {
        _navigationController.ShowScreen<MainScreen>();
    }
}
