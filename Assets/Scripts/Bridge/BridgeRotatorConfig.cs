using UnityEngine;

[CreateAssetMenu(menuName = "Data/" + nameof(BridgeRotatorConfig))]
public class BridgeRotatorConfig : ScriptableObject
{
    public float RotationDuration => _rotationDuration;

    [SerializeField] private float _rotationDuration = 1f;
}
