using System;
using System.Collections;
using System.Collections.Generic;
using com.petrushevskiapps.menumanager;
using UnityEngine;
using UnityEngine.UI;

public class UIMainScreen : UIScreen
{
    [SerializeField] private Button btnScreen1;
    [SerializeField] private Button btnScreen2;
    [SerializeField] private Button btnScreen3;
    private void Awake()
    {
        btnScreen1.onClick.AddListener(ShowScreen1);
        btnScreen2.onClick.AddListener(ShowScreen2);
        btnScreen3.onClick.AddListener(ShowScreen3);
    }

    private void OnDestroy()
    {
        btnScreen1.onClick.RemoveListener(ShowScreen1);
        btnScreen2.onClick.RemoveListener(ShowScreen2);
        btnScreen3.onClick.RemoveListener(ShowScreen3);
    }

    private void ShowScreen1()
    {
        MenuManager.Instance.OpenScreen<UIScreen1>();
    }
    private void ShowScreen2()
    {
        MenuManager.Instance.OpenScreen<UIScreen2>();
    }
    private void ShowScreen3()
    {
        MenuManager.Instance.OpenScreen<UIScreen3>();
    }
}
