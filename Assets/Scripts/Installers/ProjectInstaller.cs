using System;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private BridgeGrowerConfig _bridgeGrowerCfg;
    [SerializeField] private BridgeRotatorConfig _bridgeRotatorCfg;
    [SerializeField] private ColumnSpawnerConfig _columnSpawnerCfg;
    [SerializeField] private ColumnSpawnPointsConfig _columnSpawnPointsCfg;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private ColumnMover _columnSpawnPoints;
    
    public override void InstallBindings()
    {
        BindConfigs();
        BindPlayerController();
        BindColumnSpawnPoints();
        LaunchStateMachine();
    }

    private void BindPlayerController()
    {
        GameObject playerController = Container.InstantiatePrefab(_playerController);
        Container.Bind<PlayerController>().FromInstance(playerController.GetComponent<PlayerController>()).AsSingle();
    }

    private void BindColumnSpawnPoints()
    {
        GameObject columnSpawnPoints = Container.InstantiatePrefab(_columnSpawnPoints);
        Container.Bind<ColumnMover>().FromInstance(columnSpawnPoints.GetComponent<ColumnMover>()).AsSingle();
    }

    private void LaunchStateMachine()
    {
        Container.Bind<GameStateMachine>().AsSingle();
        Container.Resolve<GameStateMachine>().EnterState<InstallingState>();
    }

    private void BindConfigs()
    {
        Container.Bind<BridgeGrowerConfig>().FromInstance(_bridgeGrowerCfg).AsSingle();
        Container.Bind<BridgeRotatorConfig>().FromInstance(_bridgeRotatorCfg).AsSingle();
        Container.Bind<ColumnSpawnerConfig>().FromInstance(_columnSpawnerCfg).AsSingle();
        Container.Bind<ColumnSpawnPointsConfig>().FromInstance(_columnSpawnPointsCfg).AsSingle();
    }
}
