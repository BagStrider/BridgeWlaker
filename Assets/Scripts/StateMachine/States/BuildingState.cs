using System.Collections;
using UnityEngine;
using Zenject;

public class BuildingState : State
{
    private InputController _playerController;
    private ColumnPair _columnPair;
    private BridgeRotator _bridgeRotator;

    public BuildingState(InputController playerController, ColumnPair columnPair)
    {
        _playerController = playerController;
        _columnPair = columnPair;
    }

    public override void Enter()
    {
        _bridgeRotator = _columnPair.FristColumn.Bridge.ResolveComponent<BridgeRotator>();

        _bridgeRotator.Rotated += BridgeRotatedHandle;
        _playerController.Pressed += PressedLMBHandle;
        _playerController.Released += ReleasedLMBHandle;
    }

    private void BridgeRotatedHandle()
    {
        StateMachine.EnterState<WalkingState>();
    }
    private void PressedLMBHandle()
    {
        _columnPair.FristColumn.Bridge.ResolveComponent<BridgeGrower>().GrowUp();
    }
    private void ReleasedLMBHandle()
    {
        _bridgeRotator.Rotate(Quaternion.Euler(0f,0f,-90f));
    }
    public override void Exit()
    {
        _bridgeRotator.Rotated -= BridgeRotatedHandle;
        _playerController.Pressed -= PressedLMBHandle;
        _playerController.Released -= ReleasedLMBHandle;
    }
}
