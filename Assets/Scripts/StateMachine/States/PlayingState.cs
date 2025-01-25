using UnityEngine;
using Zenject;

public class PlayingState : State
{
    private PlayerController _playerController;
    private ColumnSpawner _columnSpawner;
    private Column _currentColumn;
    private Column _nextColumn;

    public PlayingState(PlayerController playerController, ColumnSpawner columnSpawner)
    {
        _playerController = playerController;
        _columnSpawner = columnSpawner;
    }

    public override void Enter()
    {
        _currentColumn = _columnSpawner.SpawnColumn(Vector3.zero);
        _playerController.Pressed += PlayerPressedHandle;
        _playerController.PressedRMB += PlayerPressedRMBHandle; //test
    }

    public override void Exit()
    {

        //test
        _playerController.Pressed -= PlayerPressedHandle;
        _playerController.PressedRMB -= PlayerPressedRMBHandle; //test
    }

    private void PlayerPressedHandle()
    {
        _currentColumn.Bridge.ResolveComponent<BridgeGrower>().GrowUp();
    }
    private void PlayerPressedRMBHandle()
    {
        _currentColumn.Bridge.ResolveComponent<BridgeRotator>().Rotate(Quaternion.Euler(0f,0f,-90f)); //test
    }

    private void CheckBridgeLength()
    {
        float columnDistance = Vector3.Distance(_currentColumn.BridgeStartSpot.position, _nextColumn.BridgeEndSpot.position);
        float columnMaxDistance = Vector3.Distance(_currentColumn.BridgeStartSpot.position, _nextColumn.BridgeStartSpot.position);

        float bridgeLength = _currentColumn.Bridge.transform.localScale.y / 0.1f; //magic number = original bridge scale

        if(bridgeLength < columnDistance || bridgeLength >= columnMaxDistance + 0.1f)
        {
            StateMachine.EnterState<LosingState>();
        }

        StateMachine.EnterState<WinningState>();
    }
}
