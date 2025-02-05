using UnityEngine;

public class BootstrapState : State
{
    private ColumnSpawner _columnSpawner;
    private ColumnPair _columnPair;

    public BootstrapState(ColumnSpawner columnSpawner, ColumnPair columnPair)
    {
        _columnSpawner = columnSpawner;
        _columnPair = columnPair;
    }

    public override void Enter()
    {
        Column first = _columnSpawner.SpawnColumn(Vector3.zero);
        Column second = _columnSpawner.SpawnColumn(new Vector3(10f, 0f, 0f));

        _columnPair.SetColumnPair(first, second);

        StateMachine.EnterState<BuildingState>();
    }
}