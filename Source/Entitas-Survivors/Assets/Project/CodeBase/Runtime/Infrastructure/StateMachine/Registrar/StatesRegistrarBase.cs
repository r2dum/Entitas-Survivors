using System;
using System.Collections.Generic;

namespace CodeBase.Runtime.Infrastructure.StateMachine.Registrar
{
  public abstract class StatesRegistrarBase : IStatesRegistrar
  {
    private readonly StateMachine _stateMachine;
    private readonly IStateFactory _stateFactory;

    private readonly List<Type> _registeredTypes = new();

    protected StatesRegistrarBase(StateMachine stateMachine, IStateFactory stateFactory)
    {
      _stateMachine = stateMachine;
      _stateFactory = stateFactory;
    }

    protected void Register<TState>() where TState : class, IExitState
    {
      _stateMachine.RegisterState(_stateFactory.Create<TState>());
      _registeredTypes.Add(typeof(TState));
    }

    public abstract void RegisterStates();

    public void Dispose()
    {
      foreach (Type stateType in _registeredTypes)
        _stateMachine.UnregisterState(stateType);

      _registeredTypes.Clear();
    }
  }
}