using System.Collections;
using System.Collections.Generic;
using com.petrushevskiapps.menumanager;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIScreen1 : UIScreen
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button btnScreen2;
    [SerializeField] private Button btnScreen3;
    [SerializeField] private Button btnPopup;
    private void Awake()
    {
        backButton.onClick.AddListener(UseBackButton);
        btnScreen2.onClick.AddListener(ShowScreen2);
        btnScreen3.onClick.AddListener(ShowScreen3);
        btnPopup.onClick.AddListener(ShowPopup);
    }

    

    private void OnDestroy()
    {
        backButton.onClick.RemoveListener(UseBackButton);
        btnScreen2.onClick.RemoveListener(ShowScreen2);
        btnScreen3.onClick.RemoveListener(ShowScreen3);
        btnPopup.onClick.AddListener(ShowPopup);
    }

    private void UseBackButton()
    {
        OnBackButtonPressed();
    }
    private void ShowPopup()
    {
        MenuManager.Instance.OpenPopup<UIPopup1>();
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
