using CodeBase.Runtime.Gameplay.GameplayStaticData;
using CodeBase.Runtime.Infrastructure.Debug.Log;
using CodeBase.Runtime.Infrastructure.StateMachine;

namespace CodeBase.Runtime.Infrastructure.GameFlowStateMachine.MeadowStates
{
  public class MeadowBootstrapState : IState
  {
    private readonly IGameplayStaticDataService _staticDataService;
    private readonly GameStateMachine _gameStateMachine;
    private readonly ILogService _logService;

    public MeadowBootstrapState(IGameplayStaticDataService staticDataService, GameStateMachine gameStateMachine, ILogService logService)
    {
      _staticDataService = staticDataService;
      _gameStateMachine = gameStateMachine;
      _logService = logService;
    }

    public async void Enter()
    {
      _logService.Write("Enter " + nameof(MeadowBootstrapState));
      await _staticDataService.LoadAllAsync();
      _gameStateMachine.Enter<MeadowBattleLoopState>();
    }

    public void Exit() =>
      _logService.Write("Exit " + nameof(MeadowBootstrapState));
  }
}