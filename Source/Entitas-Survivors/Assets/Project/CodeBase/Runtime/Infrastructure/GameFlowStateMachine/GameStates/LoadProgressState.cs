using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Common.Times;
using CodeBase.Runtime.Infrastructure.Debugs.Log;
using CodeBase.Runtime.Infrastructure.StateMachine;
using CodeBase.Runtime.Progress.Data;
using CodeBase.Runtime.Progress.Provider;
using CodeBase.Runtime.Services.StaticData;

namespace CodeBase.Runtime.Infrastructure.GameFlowStateMachine.GameStates
{
  public class LoadProgressState : IState
  {
    private readonly GameStateMachine _gameStateMachine;
    private readonly IStaticDataService _staticDataService;
    private readonly IProgressProvider _progressProvider;
    private readonly ITimeService _timeService;
    private readonly ILogService _logService;

    public LoadProgressState(GameStateMachine gameStateMachine, IStaticDataService staticDataService,
      IProgressProvider progressProvider, ITimeService timeService,
      ILogService logService)
    {
      _gameStateMachine = gameStateMachine;
      _staticDataService = staticDataService;
      _progressProvider = progressProvider;
      _timeService = timeService;
      _logService = logService;
    }

    public void Enter()
    {
      _logService.Write("Enter " + nameof(LoadProgressState));
      InitializeProgress();
      _gameStateMachine.Enter<ActualizeProgressState>();
    }

    public void Exit() =>
      _logService.Write("Exit " + nameof(LoadProgressState));

    private void InitializeProgress() =>
      CreateNewProgress();

    private void CreateNewProgress()
    {
      _progressProvider.SetProgressData(new ProgressData
      {
        LastSimulationTickTime = _timeService.UtcNow
      });

      CreateMetaEntity.Empty()
        .With(x => x.isStorage = true)
        .AddGold(0f)
        .AddGoldPerSecond(_staticDataService.GetAfkGainConfig().GoldPerSecond);
    }
  }
}