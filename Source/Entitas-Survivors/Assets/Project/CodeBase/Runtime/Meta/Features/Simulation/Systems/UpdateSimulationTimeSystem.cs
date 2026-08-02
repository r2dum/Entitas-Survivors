using CodeBase.Runtime.Progress.Provider;
using Entitas;

namespace CodeBase.Runtime.Meta.Features.Simulation.Systems
{
  public class UpdateSimulationTimeSystem : IExecuteSystem
  {
    private readonly IProgressProvider _progressProvider;

    private readonly IGroup<MetaEntity> _ticks;

    public UpdateSimulationTimeSystem(MetaContext metaContext, IProgressProvider progressProvider)
    {
      _progressProvider = progressProvider;
      _ticks = metaContext.GetGroup(MetaMatcher.Tick);
    }

    public void Execute()
    {
      foreach (MetaEntity tick in _ticks)
      {
        _progressProvider.ProgressData.LastSimulationTickTime =
          _progressProvider.ProgressData.LastSimulationTickTime
            .AddSeconds(tick.Tick);
      }
    }
  }
}