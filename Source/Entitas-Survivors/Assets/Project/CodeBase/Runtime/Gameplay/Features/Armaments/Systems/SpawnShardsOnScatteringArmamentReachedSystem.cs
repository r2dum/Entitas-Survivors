using System.Collections.Generic;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Gameplay.Features.Abilities.Configs;
using CodeBase.Runtime.Gameplay.Features.Armaments.Factory;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
using Entitas;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Armaments.Systems
{
  public class SpawnShardsOnScatteringArmamentReachedSystem : IExecuteSystem
  {
    private readonly IGameplayStaticDataService _staticDataService;
    private readonly IArmamentFactory _armamentFactory;

    private readonly IGroup<GameEntity> _armaments;
    private readonly List<GameEntity> _buffer = new(64);

    public SpawnShardsOnScatteringArmamentReachedSystem(GameContext gameContext, IGameplayStaticDataService staticDataService,
      IArmamentFactory armamentFactory)
    {
      _staticDataService = staticDataService;
      _armamentFactory = armamentFactory;

      _armaments = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament,
          GameMatcher.WorldPosition,
          GameMatcher.ParentAbility,
          GameMatcher.ProducerId,
          GameMatcher.Scattering,
          GameMatcher.Reached));
    }

    public void Execute()
    {
      foreach (GameEntity armament in _armaments.GetEntities(_buffer))
      {
        AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(armament.ParentAbility, 1);
        SpawnShards(armament, abilityLevel.ScatteringSetup);
      }
    }

    private void SpawnShards(GameEntity parentArmament, ScatteringSetup setup)
    {
      int shardCount = setup.ProjectileSetup.ProjectileCount;
      Vector3 spawnPosition = parentArmament.WorldPosition;

      foreach (Vector2 direction in GetRadialDirections(shardCount))
      {
        _armamentFactory
          .CreateScatteringFireBallShard(1, spawnPosition)
          .AddProducerId(parentArmament.ProducerId)
          .ReplaceDirection(direction)
          .With(x => x.isMoving = true);
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