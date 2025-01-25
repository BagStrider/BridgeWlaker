using UnityEngine;

[CreateAssetMenu(menuName = "Data/" + nameof(ColumnSpawnerConfig))]
public class ColumnSpawnerConfig : ScriptableObject
{
    public Column ColumnPrefab => _columnPrefab;
    public GameObject BridgePrefab => _bridgePrefab;
    public ColumnSpawner ColumnSpawnerPrefab => _columnSpawnerPrefab;
    public float MinColumnWidth => _minColumnWidth;
    public float MaxColumnWidth => _maxColumnWidth;

    [SerializeField] private Column _columnPrefab;
    [SerializeField] private GameObject _bridgePrefab;
    [SerializeField] private ColumnSpawner _columnSpawnerPrefab;
    [SerializeField] private float _minColumnWidth;
    [SerializeField] private float _maxColumnWidth;
}