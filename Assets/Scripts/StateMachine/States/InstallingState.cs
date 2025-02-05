using UnityEngine;
using Zenject;

public class InstallingState : State
{
    public InstallingState(DiContainer container)
    {
        container.Bind<BridgeGrower>().AsSingle();
        container.Bind<ColumnPair>().AsSingle();

        ColumnSpawnerConfig columnSpawnerCfg = container.Resolve<ColumnSpawnerConfig>();
        GameObject columnSpawnerInst = container.InstantiatePrefab(columnSpawnerCfg.ColumnSpawnerPrefab);
        container.Bind<ColumnSpawner>().FromInstance(columnSpawnerInst.GetComponent<ColumnSpawner>()).AsSingle();
    }

    public override void Enter()
    {
        StateMachine.EnterState<BootstrapState>();
    }
}