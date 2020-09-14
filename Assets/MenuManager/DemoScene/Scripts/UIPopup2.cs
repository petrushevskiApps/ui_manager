using System.Collections;
using System.Collections.Generic;
using com.petrushevskiapps.menumanager;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIPopup2 : UIPopup
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button btnPopup1;
    [SerializeField] private Button btnPopup3;
    
    private void Awake()
    {
        closeButton.onClick.AddListener(CloseButton);
        btnPopup1.onClick.AddListener(ShowPopup1);
        btnPopup3.onClick.AddListener(ShowPopup3);
    }

    private void OnDestroy()
    {
        closeButton.onClick.RemoveListener(CloseButton);
        btnPopup1.onClick.RemoveListener(ShowPopup1);
        btnPopup3.onClick.RemoveListener(ShowPopup3);
    }

    private void CloseButton()
    {
        OnBackButtonPressed();
    }

    private void ShowPopup1()
    {
        MenuManager.Instance.OpenPopup<UIPopup1>();
    }
    private void ShowPopup3()
    {
        MenuManager.Instance.OpenPopup<UIPopup3>();
    }
}
