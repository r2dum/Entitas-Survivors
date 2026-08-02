using CodeBase.Runtime.Infrastructure.Debugs.Log;
using CodeBase.Runtime.Infrastructure.StateMachine;
using CodeBase.Runtime.Infrastructure.Systems;
using CodeBase.Runtime.Meta;

namespace CodeBase.Runtime.Infrastructure.GameFlowStateMachine.LobbyStates
{
  public class LobbyFeatureState : IState, IUpdateable
  {
    private readonly ISystemFactory _systemFactory;
    private readonly GameContext _gameContext;
    private readonly ILogService _logService;

    private LobbyFeature _lobbyFeature;

    public LobbyFeatureState(ISystemFactory systemFactory, GameContext gameContext, ILogService logService)
    {
      _systemFactory = systemFactory;
      _gameContext = gameContext;
      _logService = logService;
    }

    public void Enter()
    {
      _logService.Write("Enter " + nameof(LobbyFeatureState));
      _lobbyFeature = _systemFactory.Create<LobbyFeature>();
      _lobbyFeature.Initialize();
    }

    public void Update()
    {
      _lobbyFeature.Execute();
      _lobbyFeature.Cleanup();
    }

    public void Exit()
    {
      _logService.Write("Enter " + nameof(LobbyFeatureState));

      _lobbyFeature.DeactivateReactiveSystems();
      _lobbyFeature.ClearReactiveSystems();

      DestructEntities();

      _lobbyFeature.Cleanup();
      _lobbyFeature.TearDown();
      _lobbyFeature = null;
    }

    private void DestructEntities()
    {
      foreach (GameEntity entity in _gameContext.GetEntities())
        entity.isDestructed = true;
    }
  }
}