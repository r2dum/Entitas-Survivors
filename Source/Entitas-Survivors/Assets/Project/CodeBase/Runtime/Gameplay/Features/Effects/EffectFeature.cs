using CodeBase.Runtime.Gameplay.Features.Effects.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.Effects
{
  public sealed class EffectFeature : Feature
  {
    public EffectFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<RemoveEffectsWithoutTargetsSystem>());

      Add(systemFactory.Create<ProcessDamageEffectSystem>());
      Add(systemFactory.Create<ProcessHealEffectSystem>());

      Add(systemFactory.Create<CleanupProcessedEffects>());
    }
  }
}