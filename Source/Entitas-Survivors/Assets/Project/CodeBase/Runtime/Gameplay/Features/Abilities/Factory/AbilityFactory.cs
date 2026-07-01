using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Gameplay.Features.Abilities.Configs;
using CodeBase.Runtime.Gameplay.Features.Cooldowns;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
using CodeBase.Runtime.Infrastructure.Identifiers;

namespace CodeBase.Runtime.Gameplay.Features.Abilities.Factory
{
  public class AbilityFactory : IAbilityFactory
  {
    private readonly IIdentifierService _identifierService;
    private readonly IGameplayStaticDataService _staticDataService;

    public AbilityFactory(IIdentifierService identifierService, IGameplayStaticDataService staticDataService)
    {
      _identifierService = identifierService;
      _staticDataService = staticDataService;
    }

    public GameEntity CreateVegetableBoltAbility(int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.VegetableBolt, level);

      return CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .AddAbilityId(AbilityId.VegetableBolt)
        .AddCooldown(abilityLevel.Cooldown)
        .With(x => x.isVegetableBoltAbility = true)
        .PutOnCooldown();
    }

    public GameEntity CreateRadialEnergyOrb(int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.RadialEnergyOrb, level);

      return CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .AddAbilityId(AbilityId.RadialEnergyOrb)
        .AddCooldown(abilityLevel.Cooldown)
        .With(x => x.isRadialEnergyOrbAbility = true)
        .PutOnCooldown();
    }

    public GameEntity CreateOrbitingMushroomAbility(int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, level);

      return CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .AddAbilityId(AbilityId.OrbitingMushroom)
        .AddCooldown(abilityLevel.Cooldown)
        .With(x => x.isOrbitingMushroomAbility = true)
        .PutOnCooldown();
    }

    public GameEntity CreateBouncingRuneStoneAbility(int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.BouncingRuneStone, level);

      return CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .AddAbilityId(AbilityId.BouncingRuneStone)
        .AddCooldown(abilityLevel.Cooldown)
        .With(x => x.isBouncingRuneStoneAbility = true)
        .PutOnCooldown();
    }

    public GameEntity CreateScatteringFireBallAbility(int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.ScatteringFireBall, level);

      return CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .AddAbilityId(AbilityId.ScatteringFireBall)
        .AddCooldown(abilityLevel.Cooldown)
        .With(x => x.isScatteringFireBallAbility = true)
        .PutOnCooldown();
    }

    public GameEntity CreateGarlicAuraAbility() =>
      CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .AddAbilityId(AbilityId.GarlicAura)
        .With(x => x.isGarlicAuraAbility = true);
  }
}