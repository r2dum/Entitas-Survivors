using Zenject;

namespace CodeBase.Runtime.Infrastructure.StateMachine
{
  public class StateFactory : IStateFactory
  {
    private readonly IInstantiator _instantiator;

    public StateFactory(IInstantiator instantiator) =>
      _instantiator = instantiator;

    public TState Create<TState>() where TState : IExitState =>
      _instantiator.Instantiate<TState>();
  }
}