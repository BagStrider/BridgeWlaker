public class LosingState : State
{
    public LosingState()
    {

    }

    public override void Enter()
    {
       
    }
}

public class WinningState : State
{
    public WinningState()
    {

    }

    public override void Enter()
    {


        StateMachine.EnterState<PlayingState>();
    }
}