using UnityEngine;
using Zenject;

public class ColumnSpawner : MonoBehaviour
{
    [Inject] private ColumnSpawnerConfig _columnSpawnerCfg;
    [Inject] private DiContainer _container;

    public Column SpawnColumn(Vector3 posToSpawn)
    {
        GameObject columnInst = _container.InstantiatePrefab(_columnSpawnerCfg.ColumnPrefab, posToSpawn, Quaternion.identity, transform);
        Column column = columnInst.GetComponent<Column>();
        
        RandomSize(column);
        
        GameObject bridgeInst = _container.InstantiatePrefab(_columnSpawnerCfg.BridgePrefab, column.BridgeStartSpot.position, Quaternion.identity, transform);
        Bridge bridge = bridgeInst.GetComponent<Bridge>();
        column.SetBridge(bridge);
        
        return column;
    }
    
    private void RandomSize(Column column)
    {
        float columnWidth = Random.Range(_columnSpawnerCfg.MinColumnWidth, _columnSpawnerCfg.MaxColumnWidth);
        column.SetColumnSize(columnWidth, 1f);
    }
}
