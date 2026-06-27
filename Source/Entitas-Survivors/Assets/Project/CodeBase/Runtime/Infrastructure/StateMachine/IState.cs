namespace CodeBase.Runtime.Infrastructure.StateMachine
{
  public interface IState : IExitState
  {
    void Enter();
  }
}