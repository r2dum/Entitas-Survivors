using CodeBase.Runtime.Gameplay.Features.EffectApplication.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.EffectApplication
{
  public sealed class EffectApplicationFeature : Feature
  {
    public EffectApplicationFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<ApplyEffectsOnTargetsSystem>());
      Add(systemFactory.Create<ApplyStatusesOnTargetsSystem>());
    }
  }
}