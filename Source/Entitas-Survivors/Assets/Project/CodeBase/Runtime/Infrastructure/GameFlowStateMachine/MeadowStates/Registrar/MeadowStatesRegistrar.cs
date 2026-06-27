using CodeBase.Runtime.Infrastructure.StateMachine;
using CodeBase.Runtime.Infrastructure.StateMachine.Registrar;

namespace CodeBase.Runtime.Infrastructure.GameFlowStateMachine.MeadowStates.Registrar
{
  public class MeadowStatesRegistrar : StatesRegistrarBase
  {
    public MeadowStatesRegistrar(GameStateMachine stateMachine, IStateFactory stateFactory) : base(stateMachine, stateFactory) {}

    public override void RegisterStates()
    {
      Register<MeadowBootstrapState>();
      Register<MeadowBattleLoopState>();
    }
  }
}