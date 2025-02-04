using UnityEngine;

[CreateAssetMenu(menuName = "Data/" + nameof(ColumnSpawnPointsConfig))]
public class ColumnSpawnPointsConfig : ScriptableObject
{
    public float MoveToPointsDuration => _moveToPointsDuration;

    [SerializeField] private float _moveToPointsDuration = 1f;
}