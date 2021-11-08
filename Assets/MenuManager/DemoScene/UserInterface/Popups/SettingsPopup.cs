using System.Collections;
using System.Collections.Generic;
using com.petrushevskiapps.menumanager;
using PetrushevskiApps.UIManager;
using UnityEngine;

public class SettingsPopup : UIPopup
{
    [Header("Toggle Buttons")]
    [SerializeField] private GameObject audioButtonObject;
    [SerializeField] private GameObject musicToggleObject;

    [SerializeField] private UIButton rateUsButton;

    [Header("Privacy Settings")]
    [SerializeField] private UIButton privacySettingsButton;
    [SerializeField] private string privacySettingsURL;
    [SerializeField] private UIButton privacyPolicyButton;
    [SerializeField] private string privacyPolicyURL;
    [SerializeField] private UIButton termsOfUseButton;
    [SerializeField] private string termsOfUseURL;

    private UIButton audioButton;
    private UIButton musicButton;

    private UIToggle audioToggle;
    private UIToggle musicToggle;

    private void Awake()
    {
        audioButton = audioButtonObject.GetComponent<UIButton>();
        audioToggle = audioButtonObject.GetComponent<UIToggle>();

        musicButton = musicToggleObject.GetComponent<UIButton>();
        musicToggle = musicToggleObject.GetComponent<UIToggle>();

        audioButton.onClick.AddListener(OnAudioToggleClick);
        musicButton.onClick.AddListener(OnMusicToggleClick);
        privacySettingsButton.onClick.AddListener(OnPrivacySettingsClick);
        privacyPolicyButton.onClick.AddListener(OnPrivacyPolicyClick);
        termsOfUseButton.onClick.AddListener(OnTermsOfUseClick);
        rateUsButton.onClick.AddListener(OnRateUsClick);

        SetupToggles();
    }

    private void SetupToggles()
    {
        //audioToggle.ToggleStatus = PlayerDataController.AudioToggle;
        //musicToggle.ToggleStatus = PlayerDataController.MusicToggle;
    }

    private void OnRateUsClick()
    {
        Debug.Log("Rate Us Button Clicked");
    }

    private void OnTermsOfUseClick()
    {
        OpenURL(termsOfUseURL);
    }

    private void OnPrivacyPolicyClick()
    {
        OpenURL(privacyPolicyURL);
    }

    private void OnPrivacySettingsClick()
    {
        OpenURL(privacySettingsURL);
    }

    private void OnMusicToggleClick()
    {
        //PlayerDataController.MusicToggle = !PlayerDataController.MusicToggle;
        //musicToggle.ToggleStatus = PlayerDataController.MusicToggle;
    }

    private void OnAudioToggleClick()
    {
        //PlayerDataController.AudioToggle = !PlayerDataController.AudioToggle;
        //audioToggle.ToggleStatus = PlayerDataController.AudioToggle;
    }

    private void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
