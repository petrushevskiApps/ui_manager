using GameToolkit.Managers.TutorialManager;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Scripts.Tutorial
{
    [CreateAssetMenu(
        fileName = "TextTutorialData",
        menuName = "Game Manager/Tutorial Data/Text Tutorial Data",
        order = 1)]
    public class TextTutorialData : TutorialData
    {
        [field: SerializeField]
        public string Title { get; [UsedImplicitly] private set; }
        [field: SerializeField]
        public string Description { get; [UsedImplicitly] private set; }
    }
}