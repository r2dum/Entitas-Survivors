using CodeBase.Runtime.Common.Destruct;
using CodeBase.Runtime.Infrastructure.Systems;
using CodeBase.Runtime.Meta.Features.Simulation;
using CodeBase.Runtime.Meta.Features.Simulation.Systems;

namespace CodeBase.Runtime.Meta
{
  public sealed class LobbyFeature : Feature
  {
    public LobbyFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<EmitTickSystem>(MetaConstants.SimulationTickSeconds));

      Add(systemFactory.Create<SimulationFeature>());

      Add(systemFactory.Create<CleanupTickSystem>());
      Add(systemFactory.Create<ProcessDestructedFeature>());
    }
  }
}