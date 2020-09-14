using System.Collections;
using System.Collections.Generic;
using com.petrushevskiapps.menumanager;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIScreen3 : UIScreen
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button btnScreen1;
    [SerializeField] private Button btnScreen2;
    [SerializeField] private Button btnPopup;

    private void Awake()
    {
        backButton.onClick.AddListener(UseBackButton);
        btnScreen1.onClick.AddListener(ShowScreen1);
        btnScreen2.onClick.AddListener(ShowScreen2);
        btnPopup.onClick.AddListener(ShowPopup);

    }

    private void OnDestroy()
    {
        backButton.onClick.RemoveListener(UseBackButton);
        btnScreen1.onClick.RemoveListener(ShowScreen1);
        btnScreen2.onClick.RemoveListener(ShowScreen2);
        btnPopup.onClick.AddListener(ShowPopup);

    }

    private void UseBackButton()
    {
        OnBackButtonPressed();
    }
    private void ShowPopup()
    {
        MenuManager.Instance.OpenPopup<UIPopup3>();
    }
    private void ShowScreen1()
    {
        MenuManager.Instance.OpenScreen<UIScreen1>();
    }
    private void ShowScreen2()
    {
        MenuManager.Instance.OpenScreen<UIScreen2>();
    }
}
