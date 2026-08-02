using System.Collections.Generic;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Common.Math;
using CodeBase.Runtime.Gameplay.Features.Abilities.Configs;
using CodeBase.Runtime.Gameplay.Features.Abilities.Upgrade;
using CodeBase.Runtime.Gameplay.Features.Armaments.Factory;
using CodeBase.Runtime.Gameplay.Features.Cooldowns;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
using Entitas;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Abilities.Systems
{
  public class OrbitingMushroomAbilitySystem : IExecuteSystem
  {
    private readonly IGameplayStaticDataService _staticDataService;
    private readonly IArmamentFactory _armamentFactory;
    private readonly IAbilityUpgradeService _abilityUpgradeService;

    private readonly IGroup<GameEntity> _abilities;
    private readonly IGroup<GameEntity> _heroes;

    private readonly List<GameEntity> _buffer = new(1);

    public OrbitingMushroomAbilitySystem(GameContext gameContext, IGameplayStaticDataService staticDataService,
      IArmamentFactory armamentFactory, IAbilityUpgradeService abilityUpgradeService)
    {
      _staticDataService = staticDataService;
      _armamentFactory = armamentFactory;
      _abilityUpgradeService = abilityUpgradeService;

      _abilities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.OrbitingMushroomAbility,
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
        int level = _abilityUpgradeService.GetAbilityLevel(AbilityId.OrbitingMushroom);

        AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, level);
        int projectileCount = abilityLevel.ProjectileSetup.ProjectileCount;
        float[] phases = MathRadial.GetPhases(projectileCount);

        for (int i = 0; i < projectileCount; i++)
        {
          _armamentFactory
            .CreateOrbitingMushroom(level, hero.WorldPosition + Vector3.up, phases[i])
            .AddProducerId(hero.Id)
            .AddOrbitCenterPosition(hero.WorldPosition)
            .AddOrbitCenterFollowTarget(hero.Id)
            .With(x => x.isMoving = true);
        }

        ability.PutOnCooldown(abilityLevel.Cooldown);
      }
    }
  }
}