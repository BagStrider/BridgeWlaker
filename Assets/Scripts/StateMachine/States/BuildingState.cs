using System.Collections;
using UnityEngine;
using Zenject;

public class BuildingState : State
{
    private PlayerController _playerController;

    private Column _currentColumn;
    private Column _nextColumn;

    public BuildingState(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public override void Enter()
    {
        _playerController.Pressed += PlayerPressedLMBHandle;
    }

    public override void Exit()
    {
        _playerController.Pressed -= PlayerPressedLMBHandle;
    }

    private void PlayerPressedLMBHandle()
    {
        _currentColumn.Bridge.ResolveComponent<BridgeGrower>().GrowUp();
    }
    private void PlayerPressedRMBHandle()
    {
        _currentColumn.Bridge.ResolveComponent<BridgeRotator>().Rotate(Quaternion.Euler(0f,0f,-90f)); //test
    }
}