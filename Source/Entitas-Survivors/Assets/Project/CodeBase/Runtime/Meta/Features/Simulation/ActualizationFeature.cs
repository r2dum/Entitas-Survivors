using CodeBase.Runtime.Common.Destruct;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Meta.Features.Simulation
{
  public sealed class ActualizationFeature : Feature
  {
    public ActualizationFeature(ISystemFactory systems)
    {
      Add(systems.Create<SimulationFeature>());
      Add(systems.Create<ProcessDestructedFeature>());
    }
  }
}