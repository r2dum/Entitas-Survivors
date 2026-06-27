using CodeBase.Runtime.Gameplay.Features.Statuses.Systems.StatusVisuals;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.Statuses.Systems
{
  public sealed class StatusVisualsFeature : Feature
  {
    public StatusVisualsFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<ApplyPoisonVisualsSystem>());
      Add(systemFactory.Create<ApplyFreezeVisualsSystem>());

      Add(systemFactory.Create<UnapplyPoisonVisualsSystem>());
      Add(systemFactory.Create<UnapplyFreezeVisualsSystem>());
    }
  }
}