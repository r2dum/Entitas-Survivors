using System;
using System.Collections.Generic;
using CodeBase.Runtime.Common;
using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Gameplay.Features.Abilities;
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

    public GameEntity CreateEnemy(EnemyTypeId typeId, Vector2 at)
    {
      EnemyConfig enemyConfig = _gameplayStaticDataService.GetEnemyConfig(typeId);
      Dictionary<Stats, float> baseStats = CreateBaseStats(enemyConfig);
      GameEntity entity = CreateEnemyEntity(typeId, baseStats, enemyConfig.ViewAddress.AssetGUID, at);

      foreach (EnemyAbilitySetup abilitySetup in enemyConfig.AbilitySetups)
        CreateAbility(abilitySetup.AbilityId, entity.Id);

      return entity;
    }

    private GameEntity CreateEnemyEntity(EnemyTypeId typeId, Dictionary<Stats, float> baseStats, string viewAddress, Vector2 at)
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

    private void CreateAbility(AbilityId abilityId, int producerId)
    {
      switch (abilityId)
      {
        case AbilityId.HealAura:
          _abilityFactory.CreateHealAuraAbility(producerId);
          break;
        case AbilityId.SpeedUpAura:
          _abilityFactory.CreateSpeedUpAuraAbility(producerId);
          break;
        default:
          throw new Exception($"Ability {abilityId} is not supported for enemies");
      }
    }

    private Dictionary<Stats, float> CreateBaseStats(EnemyConfig enemyConfig) =>
      InitStats.EmptyStatDictionary()
        .With(x => x[Stats.Speed] = enemyConfig.Speed)
        .With(x => x[Stats.MaxHp] = enemyConfig.MaxHp)
        .With(x => x[Stats.Damage] = enemyConfig.Damage);
  }
}