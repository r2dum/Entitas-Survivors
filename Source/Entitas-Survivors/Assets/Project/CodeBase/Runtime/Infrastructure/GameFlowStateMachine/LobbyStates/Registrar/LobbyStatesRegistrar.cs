using CodeBase.Runtime.Infrastructure.StateMachine;
using CodeBase.Runtime.Infrastructure.StateMachine.Registrar;

namespace CodeBase.Runtime.Infrastructure.GameFlowStateMachine.LobbyStates.Registrar
{
  public class LobbyStatesRegistrar : StatesRegistrarBase
  {
    public LobbyStatesRegistrar(GameStateMachine stateMachine, IStateFactory stateFactory) : base(stateMachine, stateFactory)
    {
    }

    public override void RegisterStates()
    {
      Register<LobbyFeatureState>();
    }
  }
}