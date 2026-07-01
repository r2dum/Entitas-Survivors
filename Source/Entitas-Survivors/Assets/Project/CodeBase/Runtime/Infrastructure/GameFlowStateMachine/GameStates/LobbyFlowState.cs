using CodeBase.Runtime.Infrastructure.Debugs.Log;
using CodeBase.Runtime.Infrastructure.SceneLoading;
using CodeBase.Runtime.Infrastructure.StateMachine;

namespace CodeBase.Runtime.Infrastructure.GameFlowStateMachine.GameStates
{
  public class LobbyFlowState : IState
  {
    private readonly ISceneLoader _sceneLoader;
    private readonly ILogService _logService;

    public LobbyFlowState(ISceneLoader sceneLoader, ILogService logService)
    {
      _sceneLoader = sceneLoader;
      _logService = logService;
    }

    public async void Enter()
    {
      _logService.Write("Enter " + nameof(LobbyFlowState));
      await _sceneLoader.LoadAsync(Scenes.Lobby);
    }

    public void Exit() =>
      _logService.Write("Exit " + nameof(LobbyFlowState));
  }
}