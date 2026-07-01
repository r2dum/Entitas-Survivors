using CodeBase.Runtime.Infrastructure.Debugs.Log;
using CodeBase.Runtime.Infrastructure.SceneLoading;
using CodeBase.Runtime.Infrastructure.StateMachine;

namespace CodeBase.Runtime.Infrastructure.GameFlowStateMachine.GameStates
{
  public class MeadowFlowState : IState
  {
    private readonly ISceneLoader _sceneLoader;
    private readonly ILogService _logService;

    public MeadowFlowState(ISceneLoader sceneLoader, ILogService logService)
    {
      _sceneLoader = sceneLoader;
      _logService = logService;
    }

    public async void Enter()
    {
      _logService.Write("Enter " + nameof(MeadowFlowState));
      await _sceneLoader.LoadAsync(Scenes.Meadow);
    }

    public void Exit() =>
      _logService.Write("Exit " + nameof(MeadowFlowState));
  }
}