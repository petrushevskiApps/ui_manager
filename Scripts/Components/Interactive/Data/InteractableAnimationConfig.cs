using UnityEngine;

namespace TwoOneTwoGames.UIManager.Components.Interactive
{
    [CreateAssetMenu(
        menuName = "Data/Interactable Animation Configuration",
        fileName = "InteractableAnimationConfig")]
    public class InteractableAnimationConfig : ScriptableObject
    {
        [field: SerializeField]
        public Vector3 Scale { get; } = new(0.85f, 0.85f, 0.85f);

        [field: SerializeField]
        public float ScaleSpeed { get; } = 1f;
    }
}