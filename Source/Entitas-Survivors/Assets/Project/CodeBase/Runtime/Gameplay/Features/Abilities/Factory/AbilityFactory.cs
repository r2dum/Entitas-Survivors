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

    public GameEntity CreateEnergyOrb(int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.EnergyOrb, level);

      return CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .AddAbilityId(AbilityId.EnergyOrb)
        .AddCooldown(abilityLevel.Cooldown)
        .With(x => x.isEnergyOrbAbility = true)
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

    public GameEntity CreateBouncingHummerAbility(int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.BouncingHummer, level);

      return CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .AddAbilityId(AbilityId.BouncingHummer)
        .AddCooldown(abilityLevel.Cooldown)
        .With(x => x.isBouncingHummerAbility = true)
        .PutOnCooldown();
    }

    public GameEntity CreateGarlicAuraAbility() =>
      CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .AddAbilityId(AbilityId.GarlicAura)
        .With(x => x.isGarlicAuraAbility = true);
  }
}