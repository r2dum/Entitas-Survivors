using System;
using System.Collections.Generic;
using CodeBase.Runtime.Common;
using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Gameplay.Features.CharacterStats;
using CodeBase.Runtime.Gameplay.Features.Effects;
using CodeBase.Runtime.Infrastructure.Identifiers;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Factory
{
  public class EnemyFactory : IEnemyFactory
  {
    private readonly IIdentifierService _identifierService;

    public EnemyFactory(IIdentifierService identifierService) =>
      _identifierService = identifierService;

    public GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at)
    {
      switch (typeId)
      {
        case EnemyTypeId.Goblin:
          return CreateGoblin(at);
      }

      throw new Exception($"Enemy with type id {typeId} does not exist");
    }

    private GameEntity CreateGoblin(Vector2 at)
    {
      Dictionary<Stats, float> baseStats = InitStats.EmptyStatDictionary()
        .With(x => x[Stats.Speed] = 1)
        .With(x => x[Stats.MaxHp] = 3)
        .With(x => x[Stats.Damage] = 1);

      return CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .AddEnemyTypeId(EnemyTypeId.Goblin)
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
        .AddViewAddress(AssetAddress.Enemy)
        .With(x => x.isEnemy = true)
        .With(x => x.isTurnedAlongDirection = true)
        .With(x => x.isMovementAvailable = true);
    }
  }
}