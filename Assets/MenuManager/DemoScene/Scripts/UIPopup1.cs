using System.Collections;
using System.Collections.Generic;
using com.petrushevskiapps.menumanager;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIPopup1 : UIPopup
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button btnPopup2;
    [SerializeField] private Button btnPopup3;
    
    private void Awake()
    {
        closeButton.onClick.AddListener(CloseButton);
        btnPopup2.onClick.AddListener(ShowPopup2);
        btnPopup3.onClick.AddListener(ShowPopup3);
    }

    private void OnDestroy()
    {
        closeButton.onClick.RemoveListener(CloseButton);
        btnPopup2.onClick.RemoveListener(ShowPopup2);
        btnPopup3.onClick.RemoveListener(ShowPopup3);
    }

    private void CloseButton()
    {
        OnBackButtonPressed();
    }

    private void ShowPopup2()
    {
        MenuManager.Instance.OpenPopup<UIPopup2>();
    }
    private void ShowPopup3()
    {
        MenuManager.Instance.OpenPopup<UIPopup3>();
    }
}
