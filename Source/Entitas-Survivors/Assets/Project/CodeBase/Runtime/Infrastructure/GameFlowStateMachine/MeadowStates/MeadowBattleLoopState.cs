using CodeBase.Runtime.Gameplay;
using CodeBase.Runtime.Infrastructure.Debug.Log;
using CodeBase.Runtime.Infrastructure.StateMachine;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Infrastructure.GameFlowStateMachine.MeadowStates
{
  public class MeadowBattleLoopState : IState, IUpdateable
  {
    private readonly ISystemFactory _systemFactory;
    private readonly GameContext _gameContext;
    private readonly ILogService _logService;

    private BattleFeature _battleFeature;

    public MeadowBattleLoopState(ISystemFactory systemFactory, GameContext gameContext, ILogService logService)
    {
      _systemFactory = systemFactory;
      _gameContext = gameContext;
      _logService = logService;
    }

    public void Enter()
    {
      _logService.Write("Enter " + nameof(MeadowBattleLoopState));
      _battleFeature = _systemFactory.Create<BattleFeature>();
      _battleFeature.Initialize();
    }

    public void Update()
    {
      _battleFeature.Execute();
      _battleFeature.Cleanup();
    }

    public void Exit()
    {
      _logService.Write("Exit " + nameof(MeadowBattleLoopState));

      _battleFeature.DeactivateReactiveSystems();
      _battleFeature.ClearReactiveSystems();

      DestructEntities();

      _battleFeature.Cleanup();
      _battleFeature.TearDown();
      _battleFeature = null;
    }

    private void DestructEntities()
    {
      foreach (GameEntity entity in _gameContext.GetEntities())
        entity.isDestructed = true;
    }
  }
}