using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace slowBulletGames.MemoryValley
{
    public class StarsController : MonoBehaviour
    {
        [SerializeField] private GameObject key;
        [SerializeField] private TextMeshProUGUI keyText;

        private void OnEnable()
        {
            //int keysInLevelCollected = GameManager.Instance.ActiveLevel.CollectedKeysCount;
            //int keysInLevel = GameManager.Instance.ActiveLevel.GetKeysInLevel();
            //keyText.text = $"{keysInLevelCollected} / {keysInLevel} Keys Collected";
        }
    }
}
