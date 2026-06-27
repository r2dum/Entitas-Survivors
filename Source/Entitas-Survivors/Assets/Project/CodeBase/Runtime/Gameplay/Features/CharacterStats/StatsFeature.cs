using CodeBase.Runtime.Gameplay.Features.CharacterStats.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.CharacterStats
{
  public sealed class StatsFeature : Feature
  {
    public StatsFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<StatChangeSystem>());

      Add(systemFactory.Create<ApplySpeedFromStatsSystem>());
    }
  }
}