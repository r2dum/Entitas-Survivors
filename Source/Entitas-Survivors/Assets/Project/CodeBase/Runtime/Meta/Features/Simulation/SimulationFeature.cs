using CodeBase.Runtime.Infrastructure.Systems;
using CodeBase.Runtime.Meta.Features.Simulation.Systems;

namespace CodeBase.Runtime.Meta.Features.Simulation
{
  public sealed class SimulationFeature : Feature
  {
    public SimulationFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<BoosterDurationSystem>());
      Add(systemFactory.Create<CalculateGoldGainSystem>());
      
      Add(systemFactory.Create<AfkGoldGainSystem>());
      Add(systemFactory.Create<UpdateSimulationTimeSystem>());
    }
  }
}