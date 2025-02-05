public class WinningState : State
{
    public WinningState()
    {

    }

    public override void Enter()
    {


        StateMachine.EnterState<BuildingState>();
    }
}