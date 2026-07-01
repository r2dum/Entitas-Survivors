using CodeBase.Runtime.Gameplay.Features.Abilities.Systems;
using CodeBase.Runtime.Gameplay.Features.Cooldowns.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.Abilities
{
  public sealed class AbilityFeature : Feature
  {
    public AbilityFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<CooldownSystem>());

      Add(systemFactory.Create<VegetableBoltAbilitySystem>());
      Add(systemFactory.Create<OrbitingMushroomAbilitySystem>());
      Add(systemFactory.Create<RadialEnergyOrbAbilitySystem>());
      Add(systemFactory.Create<BouncingRuneStoneAbilitySystem>());
      Add(systemFactory.Create<ScatteringFireBallAbilitySystem>());

      Add(systemFactory.Create<GarlicAuraAbilitySystem>());
    }
  }
}