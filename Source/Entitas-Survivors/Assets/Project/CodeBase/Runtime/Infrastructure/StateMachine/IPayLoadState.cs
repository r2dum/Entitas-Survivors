namespace CodeBase.Runtime.Infrastructure.StateMachine
{
  public interface IPayLoadState<TPayLoad> : IExitState
  {
    void Enter(TPayLoad payLoad);
  }
}