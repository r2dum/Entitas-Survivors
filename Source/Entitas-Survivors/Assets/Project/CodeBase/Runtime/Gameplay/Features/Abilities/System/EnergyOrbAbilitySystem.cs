using System.Collections.Generic;
using System.Linq;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Gameplay.Features.Abilities.Configs;
using CodeBase.Runtime.Gameplay.Features.Armaments.Factory;
using CodeBase.Runtime.Gameplay.Features.Cooldowns;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
using Entitas;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Abilities.System
{
  public class EnergyOrbAbilitySystem : IExecuteSystem
  {
    private readonly IGameplayStaticDataService _staticDataService;
    private readonly IArmamentFactory _armamentFactory;

    private readonly IGroup<GameEntity> _abilities;
    private readonly IGroup<GameEntity> _heroes;

    private readonly List<GameEntity> _buffer = new(1);

    public EnergyOrbAbilitySystem(GameContext gameContext, IGameplayStaticDataService staticDataService, IArmamentFactory armamentFactory)
    {
      _staticDataService = staticDataService;
      _armamentFactory = armamentFactory;

      _abilities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.EnergyOrbAbility,
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
        AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.EnergyOrb, 1);
        int projectileCount = abilityLevel.ProjectileSetup.ProjectileCount;
        Vector2[] radialDirections = GetRadialDirections(projectileCount).ToArray();

        for (int i = 0; i < projectileCount; i++)
        {
          _armamentFactory
            .CreateEnergyOrb(1, hero.WorldPosition)
            .ReplaceDirection(radialDirections[i])
            .AddProducerId(hero.Id)
            .With(x => x.isMoving = true);
        }

        ability.PutOnCooldown(abilityLevel.Cooldown);
      }
    }

    private static IEnumerable<Vector2> GetRadialDirections(int count)
    {
      float angleBetween = 2 * Mathf.PI / count;
      for (int i = 0; i < count; i++)
      {
        float x = Mathf.Cos(i * angleBetween);
        float y = Mathf.Sin(i * angleBetween);
        yield return new Vector2(x, y).normalized;
      }
    }
  }
}