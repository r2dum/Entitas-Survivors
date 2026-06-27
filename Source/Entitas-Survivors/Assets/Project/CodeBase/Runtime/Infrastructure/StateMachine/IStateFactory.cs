namespace CodeBase.Runtime.Infrastructure.StateMachine
{
  public interface IStateFactory
  {
    TState Create<TState>() where TState : IExitState;
  }
}