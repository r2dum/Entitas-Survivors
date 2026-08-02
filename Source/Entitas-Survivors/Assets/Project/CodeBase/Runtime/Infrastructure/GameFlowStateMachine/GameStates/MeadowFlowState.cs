using CodeBase.Runtime.Common;
using CodeBase.Runtime.Infrastructure.AssetManagement;
using CodeBase.Runtime.Infrastructure.Debugs.Log;
using CodeBase.Runtime.Infrastructure.SceneLoading;
using CodeBase.Runtime.Infrastructure.StateMachine;

namespace CodeBase.Runtime.Infrastructure.GameFlowStateMachine.GameStates
{
  public class MeadowFlowState : IState
  {
    private readonly IAssetProvider _assetProvider;
    private readonly ISceneLoader _sceneLoader;
    private readonly ILogService _logService;

    public MeadowFlowState(IAssetProvider assetProvider, ISceneLoader sceneLoader, ILogService logService)
    {
      _assetProvider = assetProvider;
      _sceneLoader = sceneLoader;
      _logService = logService;
    }

    public async void Enter()
    {
      _logService.Write("Enter " + nameof(MeadowFlowState));
      await _assetProvider.WarmupAssetsByLabel(AssetLabel.Meadow);
      await _sceneLoader.LoadAsync(Scenes.Meadow);
    }

    public void Exit() =>
      _logService.Write("Exit " + nameof(MeadowFlowState));
  }
}