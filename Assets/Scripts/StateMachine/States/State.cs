public class State : IState, IHavingStateMachine
{
    protected StateMachine StateMachine { get; private set; }
    public void SetStateMachine(StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public virtual void Exit() { }
    public virtual void Enter() { }
}