using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public IExitableState ActiveState => _activeState;
    public IReadOnlyDictionary<Type, IExitableState> States => _states;

    private readonly Dictionary<Type, IExitableState> _states = new Dictionary<Type, IExitableState>();

    private IExitableState _activeState;

    public void AddState(IExitableState state)
    {
        _states.Add(state.GetType(), state);

        if (state is IHavingStateMachine stateMachineHaving)
        {
            stateMachineHaving.SetStateMachine(this);
        }
    }

    public bool RemoveState(IExitableState state)
    {
        return _states.Remove(state.GetType());
    }

    public bool TryGetState(Type type, out IExitableState state)
    {
        bool hasState = _states.TryGetValue(type, out state);
        return hasState;
    }

    public void EnterState<T>() where T : IState
    {
        ChangeState<T>();
    }

    private void ChangeState<T>() where T : IState
    {
        ChangeState(typeof(T));
    }

    private void ChangeState(Type toStateType)
    {
        _activeState?.Exit();

        if (TryGetState(toStateType, out var state))
        {
            _activeState = state;

            ((IState)state).Enter();
        }
        else
        {
            Debug.LogWarning($"State with type ({toStateType} is missing in the state machine)");
        }
    }
}
