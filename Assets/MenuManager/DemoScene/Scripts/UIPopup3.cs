using System.Collections;
using System.Collections.Generic;
using com.petrushevskiapps.menumanager;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIPopup3 : UIPopup
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button btnPopup1;
    [SerializeField] private Button btnPopup2;
    
    private void Awake()
    {
        closeButton.onClick.AddListener(CloseButton);
        btnPopup2.onClick.AddListener(ShowPopup2);
        btnPopup1.onClick.AddListener(ShowPopup1);
    }

    private void OnDestroy()
    {
        closeButton.onClick.RemoveListener(CloseButton);
        btnPopup2.onClick.RemoveListener(ShowPopup2);
        btnPopup1.onClick.RemoveListener(ShowPopup1);
    }

    private void CloseButton()
    {
        OnBackButtonPressed();
    }

    private void ShowPopup2()
    {
        MenuManager.Instance.OpenPopup<UIPopup2>();
    }
    private void ShowPopup1()
    {
        MenuManager.Instance.OpenPopup<UIPopup1>();
    }
}
