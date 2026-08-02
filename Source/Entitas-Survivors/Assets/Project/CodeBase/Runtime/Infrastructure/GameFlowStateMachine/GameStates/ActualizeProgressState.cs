using System;
using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Common.Times;
using CodeBase.Runtime.Infrastructure.Debugs.Log;
using CodeBase.Runtime.Infrastructure.StateMachine;
using CodeBase.Runtime.Infrastructure.Systems;
using CodeBase.Runtime.Meta;
using CodeBase.Runtime.Meta.Features.Simulation;
using CodeBase.Runtime.Progress.Data;
using CodeBase.Runtime.Progress.Provider;
using CodeBase.Runtime.Progress.SaveLoad;
using UnityEngine;

namespace CodeBase.Runtime.Infrastructure.GameFlowStateMachine.GameStates
{
  public class ActualizeProgressState : IState
  {
    private readonly GameStateMachine _stateMachine;
    private readonly IProgressProvider _progressProvider;
    private readonly ISaveLoadService _saveLoadService;
    private readonly ISystemFactory _systemFactory;
    private readonly ITimeService _timeService;
    private readonly ILogService _logService;

    private readonly TimeSpan _twoDays = TimeSpan.FromDays(2);
    private ActualizationFeature _actualizationFeature;

    public ActualizeProgressState(GameStateMachine stateMachine, IProgressProvider progressProvider,
      ISaveLoadService saveLoadService, ISystemFactory systemFactory,
      ITimeService timeService, ILogService logService)
    {
      _stateMachine = stateMachine;
      _progressProvider = progressProvider;
      _saveLoadService = saveLoadService;
      _systemFactory = systemFactory;
      _timeService = timeService;
      _logService = logService;
    }

    public void Enter()
    {
      _logService.Write("Enter " + nameof(ActualizeProgressState));

      _actualizationFeature = _systemFactory.Create<ActualizationFeature>();

      _progressProvider.ProgressData.LastSimulationTickTime = _timeService.UtcNow - _twoDays;
      
      ActualizeProgress(_progressProvider.ProgressData);

      _stateMachine.Enter<LobbyFlowState>();
    }

    public void Exit()
    {
      _logService.Write("Exit " + nameof(ActualizeProgressState));

      _actualizationFeature.Cleanup();
      _actualizationFeature.TearDown();
      _actualizationFeature = null;
    }

    private void ActualizeProgress(ProgressData data)
    {
      CreateMetaEntity.Empty()
        .AddGoldGainBoost(1f)
        .AddDuration((float)TimeSpan.FromDays(1).TotalSeconds);
      
      _actualizationFeature.Initialize();
      _actualizationFeature.DeactivateReactiveSystems();

      DateTime until = GetLimitedUntilTime(data);

      Debug.Log($"Actualizing {(until - data.LastSimulationTickTime).TotalSeconds} seconds");

      while (data.LastSimulationTickTime < until)
      {
        MetaEntity tick = CreateMetaEntity
          .Empty()
          .AddTick(MetaConstants.SimulationTickSeconds);

        _actualizationFeature.Execute();
        _actualizationFeature.Cleanup();

        tick.Destroy();
      }

      data.LastSimulationTickTime = _timeService.UtcNow;
      _saveLoadService.SaveProgress();
    }

    private DateTime GetLimitedUntilTime(ProgressData data) =>
      _timeService.UtcNow - data.LastSimulationTickTime < _twoDays
        ? _timeService.UtcNow
        : data.LastSimulationTickTime + _twoDays;
  }
}