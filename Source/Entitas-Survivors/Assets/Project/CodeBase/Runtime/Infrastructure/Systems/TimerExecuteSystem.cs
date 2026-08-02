using CodeBase.Runtime.Common.Times;
using Entitas;

namespace CodeBase.Runtime.Infrastructure.Systems
{
  public abstract class TimerExecuteSystem : IExecuteSystem
  {
    private readonly ITimeService _timeService;
    private readonly float _executeIntervalInSeconds;

    private float _timeToExecute;

    protected TimerExecuteSystem(ITimeService timeService, float executeIntervalInSeconds)
    {
      _timeService = timeService;
      _executeIntervalInSeconds = executeIntervalInSeconds;
    }

    protected abstract void Execute();

    void IExecuteSystem.Execute()
    {
      _timeToExecute -= _timeService.DeltaTime;
      if (_timeToExecute > 0f)
        return;

      _timeToExecute = _executeIntervalInSeconds;
      Execute();
    }
  }
}