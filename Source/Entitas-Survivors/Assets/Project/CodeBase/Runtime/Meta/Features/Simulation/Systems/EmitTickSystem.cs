using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Common.Times;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Meta.Features.Simulation.Systems
{
  public class EmitTickSystem : TimerExecuteSystem
  {
    private readonly float _executeIntervalInSeconds;

    public EmitTickSystem(ITimeService timeService, float executeIntervalInSeconds) :
      base(timeService, executeIntervalInSeconds)
    {
      _executeIntervalInSeconds = executeIntervalInSeconds;
    }

    protected override void Execute()
    {
      CreateMetaEntity.Empty()
        .AddTick(_executeIntervalInSeconds);
    }
  }
}