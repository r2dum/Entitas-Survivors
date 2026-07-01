using System.Collections.Generic;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Gameplay.Features.Abilities.Configs;
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

    private readonly IGroup<GameEntity> _abilities;
    private readonly IGroup<GameEntity> _heroes;

    private readonly List<GameEntity> _buffer = new(1);

    public OrbitingMushroomAbilitySystem(GameContext gameContext, IGameplayStaticDataService staticDataService, IArmamentFactory armamentFactory)
    {
      _staticDataService = staticDataService;
      _armamentFactory = armamentFactory;

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
        AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, 1);
        int projectileCount = abilityLevel.ProjectileSetup.ProjectileCount;

        for (int i = 0; i < projectileCount; i++)
        {
          float phase = 2 * Mathf.PI * i / projectileCount;

          _armamentFactory
            .CreateOrbitingMushroom(1, hero.WorldPosition + Vector3.up, phase)
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