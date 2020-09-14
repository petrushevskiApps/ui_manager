using System.Collections;
using System.Collections.Generic;
using com.petrushevskiapps.menumanager;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIScreen2 : UIScreen
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button btnScreen1;
    [SerializeField] private Button btnScreen3;
    [SerializeField] private Button btnPopup;
    
    private void Awake()
    {
        backButton.onClick.AddListener(UseBackButton);
        btnScreen1.onClick.AddListener(ShowScreen1);
        btnScreen3.onClick.AddListener(ShowScreen3);
        btnPopup.onClick.AddListener(ShowPopup);
    }

    private void OnDestroy()
    {
        backButton.onClick.RemoveListener(UseBackButton);
        btnScreen1.onClick.RemoveListener(ShowScreen1);
        btnScreen3.onClick.RemoveListener(ShowScreen3);
        btnPopup.onClick.AddListener(ShowPopup);
    }

    private void UseBackButton()
    {
        OnBackButtonPressed();
    }
    private void ShowPopup()
    {
        MenuManager.Instance.OpenPopup<UIPopup2>();
    }
    private void ShowScreen1()
    {
        MenuManager.Instance.OpenScreen<UIScreen1>();
    }
    private void ShowScreen3()
    {
        MenuManager.Instance.OpenScreen<UIScreen3>();
    }
}
