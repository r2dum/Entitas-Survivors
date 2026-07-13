using CodeBase.Runtime.Gameplay.Features.Statuses.Systems.StatusVisuals;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.Statuses.Systems
{
  public sealed class StatusVisualsFeature : Feature
  {
    public StatusVisualsFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<ApplyPoisonStatusVisualsSystem>());
      Add(systemFactory.Create<ApplyFreezeStatusVisualsSystem>());
      Add(systemFactory.Create<ApplyAppearanceSkinSystem>());

      Add(systemFactory.Create<UnapplyPoisonStatusVisualsSystem>());
      Add(systemFactory.Create<UnapplyFreezeStatusVisualsSystem>());
      Add(systemFactory.Create<UnapplyAppearanceSkinSystem>());
    }
  }
}