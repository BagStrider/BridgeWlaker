using UnityEngine;

[CreateAssetMenu(menuName = "Data/" + nameof(BridgeGrowerConfig))]
public class BridgeGrowerConfig : ScriptableObject
{
    public float GrowSpeed => _growSpeed;

    [SerializeField] private float _growSpeed = 1f;
}