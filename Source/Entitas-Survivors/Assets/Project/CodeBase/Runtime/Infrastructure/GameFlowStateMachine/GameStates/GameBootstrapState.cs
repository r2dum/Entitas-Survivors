using CodeBase.Runtime.Infrastructure.AssetManagement;
using CodeBase.Runtime.Infrastructure.Debugs.Log;
using CodeBase.Runtime.Infrastructure.StateMachine;

namespace CodeBase.Runtime.Infrastructure.GameFlowStateMachine.GameStates
{
  public class GameBootstrapState : IState
  {
    private readonly GameStateMachine _gameStateMachine;
    private readonly IAssetProvider _assetProvider;
    private readonly ILogService _logService;

    public GameBootstrapState(GameStateMachine gameStateMachine, IAssetProvider assetProvider, ILogService logService)
    {
      _gameStateMachine = gameStateMachine;
      _assetProvider = assetProvider;
      _logService = logService;
    }

    public async void Enter()
    {
      _logService.Write("Enter " + nameof(GameBootstrapState));
      await _assetProvider.InitializeAsync();
      _gameStateMachine.Enter<MeadowFlowState>();
    }

    public void Exit() =>
      _logService.Write("Exit " + nameof(GameBootstrapState));
  }
}