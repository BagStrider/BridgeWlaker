using Zenject;

public class GameStateMachine : StateMachine
{
    public GameStateMachine(DiContainer container)
    {
        AddState(container.Instantiate<InstallingState>());
        AddState(container.Instantiate<BootstrapState>());

        AddState(container.Instantiate<BuildingState>());
        AddState(container.Instantiate<WalkingState>());

        AddState(container.Instantiate<WinningState>());
        AddState(container.Instantiate<LosingState>());

        AddState(container.Instantiate<EndingState>());
    }
}
