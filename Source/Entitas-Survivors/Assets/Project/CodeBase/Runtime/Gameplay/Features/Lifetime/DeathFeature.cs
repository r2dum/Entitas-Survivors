using CodeBase.Runtime.Gameplay.Features.Lifetime.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.Lifetime
{
  public sealed class DeathFeature : Feature
  {
    public DeathFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<MarkDeadSystem>());
      Add(systemFactory.Create<UnapplyStatusesOfDeadTargetSystem>());
    }
  }
}