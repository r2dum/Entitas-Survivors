using System;
using System.Collections.Generic;
using CodeBase.Runtime.Common;
using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Gameplay.Features.Abilities.Factory;
using CodeBase.Runtime.Gameplay.Features.CharacterStats;
using CodeBase.Runtime.Gameplay.Features.Effects;
using CodeBase.Runtime.Gameplay.Features.Enemies.Configs;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
using CodeBase.Runtime.Infrastructure.Identifiers;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Factory
{
  public class EnemyFactory : IEnemyFactory
  {
    private readonly IGameplayStaticDataService _gameplayStaticDataService;
    private readonly IIdentifierService _identifierService;
    private readonly IAbilityFactory _abilityFactory;

    public EnemyFactory(IGameplayStaticDataService gameplayStaticDataService, IIdentifierService identifierService,
      IAbilityFactory abilityFactory)
    {
      _gameplayStaticDataService = gameplayStaticDataService;
      _identifierService = identifierService;
      _abilityFactory = abilityFactory;
    }

    public GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at)
    {
      switch (typeId)
      {
        case EnemyTypeId.GoblinWarrior:
          return CreateGoblinWarrior(at);
        case EnemyTypeId.GoblinHealer:
          return CreateGoblinHealer(at);
        case EnemyTypeId.GoblinSpeeder:
          return CreateGoblinSpeeder(at);
      }

      throw new Exception($"Enemy with type id {typeId} does not exist");
    }

    private GameEntity CreateGoblinWarrior(Vector2 at)
    {
      Dictionary<Stats, float> warriorStats = CreateBaseStats(EnemyTypeId.GoblinWarrior);
      return CreateEnemy(EnemyTypeId.GoblinWarrior, warriorStats, AssetAddress.GoblinTorchBlue, at);
    }

    private GameEntity CreateGoblinHealer(Vector2 at)
    {
      Dictionary<Stats, float> warriorStats = CreateBaseStats(EnemyTypeId.GoblinHealer);
      GameEntity enemy = CreateEnemy(EnemyTypeId.GoblinHealer, warriorStats, AssetAddress.GoblinTorchYellow, at);
      _abilityFactory.CreateHealAuraAbility(enemy.Id);
      return enemy;
    }

    private GameEntity CreateGoblinSpeeder(Vector2 at)
    {
      Dictionary<Stats, float> warriorStats = CreateBaseStats(EnemyTypeId.GoblinSpeeder);
      GameEntity enemy = CreateEnemy(EnemyTypeId.GoblinSpeeder, warriorStats, AssetAddress.GoblinTorchPurple, at);
      _abilityFactory.CreateSpeedUpAuraAbility(enemy.Id);
      return enemy;
    }

    private GameEntity CreateEnemy(EnemyTypeId typeId, Dictionary<Stats, float> baseStats, string viewAddress, Vector2 at)
    {
      return CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .AddEnemyTypeId(typeId)
        .AddWorldPosition(at)
        .AddDirection(Vector2.zero)
        .AddBaseStats(baseStats)
        .AddStatModifiers(InitStats.EmptyStatDictionary())
        .AddSpeed(baseStats[Stats.Speed])
        .AddCurrentHp(baseStats[Stats.MaxHp])
        .AddMaxHp(baseStats[Stats.MaxHp])
        .AddEffectSetups(new List<EffectSetup>
        {
          new()
          {
            EffectTypeId = EffectTypeId.Damage,
            Value = baseStats[Stats.Damage]
          }
        })
        .AddRadius(0.3f)
        .AddTargetBuffer(new List<int>(1))
        .AddCollectTargetsInterval(0.5f)
        .AddCollectTargetsTimer(0f)
        .AddLayerMask(CollisionLayer.Hero.AsMask())
        .AddViewAddress(viewAddress)
        .With(x => x.isEnemy = true)
        .With(x => x.isTurnedAlongDirection = true)
        .With(x => x.isMovementAvailable = true);
    }

    private Dictionary<Stats, float> CreateBaseStats(EnemyTypeId typeId)
    {
      EnemyConfig enemyConfig = _gameplayStaticDataService.GetEnemyConfig(typeId);
      return InitStats.EmptyStatDictionary()
        .With(x => x[Stats.Speed] = enemyConfig.Speed)
        .With(x => x[Stats.MaxHp] = enemyConfig.MaxHp)
        .With(x => x[Stats.Damage] = enemyConfig.Damage);
    }
  }
}