using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIText : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> texts;

    public void SetText(string text, int textId = 0)
    {
        if (textId < texts.Count)
        {
            TextMeshProUGUI tmp = texts[textId];
            tmp.text = text;
            ActivateText(textId);
        }
    }

    private void ActivateText(int activeId)
    {
        for (int i = 0; i < texts.Count; i++)
        {
            if (i == activeId)
            {
                texts[i].gameObject.SetActive(true);
                continue;
            }
            texts[i].gameObject.SetActive(false);
        }
    }
}
