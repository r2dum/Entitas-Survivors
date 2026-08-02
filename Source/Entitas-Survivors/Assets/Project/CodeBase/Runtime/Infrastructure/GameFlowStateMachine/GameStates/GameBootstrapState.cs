using CodeBase.Runtime.Infrastructure.AssetManagement;
using CodeBase.Runtime.Infrastructure.Debugs.Log;
using CodeBase.Runtime.Infrastructure.StateMachine;
using CodeBase.Runtime.Services.StaticData;

namespace CodeBase.Runtime.Infrastructure.GameFlowStateMachine.GameStates
{
  public class GameBootstrapState : IState
  {
    private readonly GameStateMachine _gameStateMachine;
    private readonly IStaticDataService _staticDataService;
    private readonly IAssetProvider _assetProvider;
    private readonly ILogService _logService;

    public GameBootstrapState(GameStateMachine gameStateMachine, IStaticDataService staticDataService,
      IAssetProvider assetProvider, ILogService logService)
    {
      _gameStateMachine = gameStateMachine;
      _staticDataService = staticDataService;
      _assetProvider = assetProvider;
      _logService = logService;
    }

    public async void Enter()
    {
      _logService.Write("Enter " + nameof(GameBootstrapState));
      await _assetProvider.InitializeAsync();
      await _staticDataService.LoadAllAsync();
      _gameStateMachine.Enter<LoadProgressState>();
    }

    public void Exit() =>
      _logService.Write("Exit " + nameof(GameBootstrapState));
  }
}