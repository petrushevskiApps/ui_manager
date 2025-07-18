using Game.Scripts.Tutorial;
using GameToolkit.Managers.TutorialManager;
using TMPro;
using UnityEngine;

public class TutorialText : MonoBehaviour, ITutorialDataHandler
{
    [SerializeField]
    private TextMeshProUGUI _title;
    [SerializeField]
    private TextMeshProUGUI _description;

    private TextTutorialData _tutorialData;

    public void Setup(TutorialData tutorialData)
    {
        if (tutorialData is TextTutorialData data)
        {
            _tutorialData = data;
            _title.text = data.Title;
            _description.text = data.Description;
            gameObject.SetActive(_tutorialData.IsActive);
        }
    }
    
    public void Clear()
    {
        if (_tutorialData != null)
        {
            gameObject.SetActive(!_tutorialData.IsActive);
            _tutorialData = null;
        }
    }
}
