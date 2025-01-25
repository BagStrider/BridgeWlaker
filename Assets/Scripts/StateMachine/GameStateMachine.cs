using Zenject;

public class GameStateMachine : StateMachine
{
    public GameStateMachine(DiContainer container)
    {
        AddState(container.Instantiate<InstallingState>());
        AddState(container.Instantiate<BootstrapState>());
        AddState(container.Instantiate<PlayingState>());
        AddState(container.Instantiate<LosingState>());
        AddState(container.Instantiate<EndingState>());
    }
}
