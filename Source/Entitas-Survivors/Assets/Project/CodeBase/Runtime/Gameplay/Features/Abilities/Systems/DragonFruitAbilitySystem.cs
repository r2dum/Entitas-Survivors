using System.Collections.Generic;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Gameplay.Features.Abilities.Configs;
using CodeBase.Runtime.Gameplay.Features.Abilities.Upgrade;
using CodeBase.Runtime.Gameplay.Features.Armaments.Factory;
using CodeBase.Runtime.Gameplay.Features.Cooldowns;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
using Entitas;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Abilities.Systems
{
  public class DragonFruitAbilitySystem : IExecuteSystem
  {
    private readonly IGameplayStaticDataService _staticDataService;
    private readonly IArmamentFactory _armamentFactory;
    private readonly IAbilityUpgradeService _abilityUpgradeService;

    private readonly IGroup<GameEntity> _abilities;
    private readonly IGroup<GameEntity> _heroes;

    private readonly List<GameEntity> _buffer = new(1);

    public DragonFruitAbilitySystem(GameContext gameContext, IGameplayStaticDataService staticDataService,
      IArmamentFactory armamentFactory, IAbilityUpgradeService abilityUpgradeService)
    {
      _staticDataService = staticDataService;
      _armamentFactory = armamentFactory;
      _abilityUpgradeService = abilityUpgradeService;

      _abilities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.DragonFruitAbility,
          GameMatcher.CooldownUp));

      _heroes = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity ability in _abilities.GetEntities(_buffer))
      foreach (GameEntity hero in _heroes)
      {
        int level = _abilityUpgradeService.GetAbilityLevel(AbilityId.DragonFruit);

        AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.DragonFruit, level);

        Vector2 randomDestination = hero.WorldPosition.ToVector2() + Random.insideUnitCircle * abilityLevel.ProjectileSetup.DestinationRadius;

        _armamentFactory
          .CreateDragonFruit(level, hero.WorldPosition)
          .AddProducerId(hero.Id)
          .AddDestination(randomDestination)
          .ReplaceDirection((randomDestination.ToVector3() - hero.WorldPosition).normalized)
          .With(x => x.isMoving = true);

        ability.PutOnCooldown(abilityLevel.Cooldown);
      }
    }
  }
}