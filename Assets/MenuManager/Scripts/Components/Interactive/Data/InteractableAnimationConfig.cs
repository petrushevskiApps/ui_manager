using UnityEngine;

[CreateAssetMenu(
    menuName = "Data/Interactable Animation Configuration", 
    fileName = "InteractableAnimationConfig")]
public class InteractableAnimationConfig : ScriptableObject
{
    [field: SerializeField]
    public Vector3 Scale { get; private set; } = new(0.85f, 0.85f, 0.85f);
    [field: SerializeField]
    public float ScaleSpeed { get; private set; } = 1f;
}
