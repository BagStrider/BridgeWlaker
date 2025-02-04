public class BootstrapState : State
{
    public override void Enter()
    {
        StateMachine.EnterState<BuildingState>();
    }
}
