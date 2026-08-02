using CodeBase.Runtime.Common.Times;
using CodeBase.Runtime.Infrastructure.Systems;
using CodeBase.Runtime.Progress.SaveLoad;

namespace CodeBase.Runtime.Progress
{
  public class PeriodicallySaveProgressSystem : TimerExecuteSystem
  {
    private readonly ISaveLoadService _saveLoadService;

    public PeriodicallySaveProgressSystem(ITimeService timeService, float executeIntervalSeconds,
      ISaveLoadService saveLoadService) : base(timeService, executeIntervalSeconds)
    {
      _saveLoadService = saveLoadService;
    }

    protected override void Execute() =>
      _saveLoadService.SaveProgress();
  }
}