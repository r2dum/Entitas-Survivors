using System.Collections.Generic;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Common.Math;
using CodeBase.Runtime.Gameplay.Features.Abilities;
using CodeBase.Runtime.Gameplay.Features.Abilities.Configs;
using CodeBase.Runtime.Gameplay.Features.Abilities.Upgrade;
using CodeBase.Runtime.Gameplay.Features.Armaments.Factory;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
using Entitas;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Armaments.Systems
{
  public class SpawnShardsOnScatteringFireBallReachedSystem : IExecuteSystem
  {
    private readonly IGameplayStaticDataService _staticDataService;
    private readonly IArmamentFactory _armamentFactory;
    private readonly IAbilityUpgradeService _abilityUpgradeService;

    private readonly IGroup<GameEntity> _armaments;

    public SpawnShardsOnScatteringFireBallReachedSystem(GameContext gameContext, IGameplayStaticDataService staticDataService,
      IArmamentFactory armamentFactory, IAbilityUpgradeService abilityUpgradeService)
    {
      _staticDataService = staticDataService;
      _armamentFactory = armamentFactory;
      _abilityUpgradeService = abilityUpgradeService;

      _armaments = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament,
          GameMatcher.ScatteringFireBallArmament,
          GameMatcher.WorldPosition,
          GameMatcher.Reached));
    }

    public void Execute()
    {
      foreach (GameEntity armament in _armaments)
      {
        int level = _abilityUpgradeService.GetAbilityLevel(AbilityId.ScatteringFireBall);
        AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.ScatteringFireBall, level);
        SpawnShards(armament, abilityLevel.ChildArmamentSetup, level);
      }
    }

    private void SpawnShards(GameEntity parentArmament, ChildArmamentSetup setup, int level)
    {
      int shardCount = setup.ProjectileSetup.ProjectileCount;
      Vector3 spawnPosition = parentArmament.WorldPosition;

      foreach (Vector2 direction in MathRadial.GetRadialDirections(shardCount))
      {
        _armamentFactory
          .CreateScatteringFireBallShard(level, spawnPosition)
          .ReplaceDirection(direction)
          .With(x => x.isMoving = true);
      }
    }
  }
}