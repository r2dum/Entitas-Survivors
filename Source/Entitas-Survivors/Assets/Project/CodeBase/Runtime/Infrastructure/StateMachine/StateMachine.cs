using System;
using System.Collections.Generic;
using Zenject;

namespace CodeBase.Runtime.Infrastructure.StateMachine
{
  public abstract class StateMachine : ITickable
  {
    private readonly Dictionary<Type, IExitState> _registeredStates = new();
    private IExitState _currentState;

    public void RegisterState<TState>(TState state) where TState : IExitState =>
      _registeredStates.Add(typeof(TState), state);

    public void UnregisterState<TState>() where TState : IExitState =>
      UnregisterState(typeof(TState));

    public void UnregisterState(Type stateType) =>
      _registeredStates.Remove(stateType);

    public void Tick()
    {
      if (_currentState is IUpdateable updateableState)
        updateableState.Update();
    }

    public void Enter<TState>() where TState : class, IState
    {
      TState state = ChangeState<TState>();
      state.Enter();
    }

    public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadState<TPayLoad>
    {
      TState state = ChangeState<TState>();
      state.Enter(payLoad);
    }

    private TState ChangeState<TState>() where TState : class, IExitState
    {
      _currentState?.Exit();
      TState state = GetState<TState>();
      _currentState = state;
      return state;
    }

    private TState GetState<TState>() where TState : class, IExitState =>
      _registeredStates[typeof(TState)] as TState;
  }
}