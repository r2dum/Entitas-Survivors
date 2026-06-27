using CodeBase.Runtime.Infrastructure.StateMachine;
using CodeBase.Runtime.Infrastructure.StateMachine.Registrar;

namespace CodeBase.Runtime.Infrastructure.GameFlowStateMachine.GameStates.Registrar
{
  public class GameStatesRegistrar : StatesRegistrarBase
  {
    public GameStatesRegistrar(GameStateMachine stateMachine, IStateFactory stateFactory) : base(stateMachine, stateFactory) {}

    public override void RegisterStates()
    {
      Register<GameBootstrapState>();
      Register<LobbyFlowState>();
      Register<MeadowFlowState>();
    }
  }
}