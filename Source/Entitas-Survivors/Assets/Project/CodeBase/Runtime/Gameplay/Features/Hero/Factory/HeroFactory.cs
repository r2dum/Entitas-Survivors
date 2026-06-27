using System.Collections.Generic;
using CodeBase.Runtime.Common;
using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Gameplay.Features.CharacterStats;
using CodeBase.Runtime.Infrastructure.Identifiers;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Hero.Factory
{
  public class HeroFactory : IHeroFactory
  {
    private readonly IIdentifierService _identifierService;

    public HeroFactory(IIdentifierService identifierService) =>
      _identifierService = identifierService;

    public GameEntity CreateHero(Vector3 at)
    {
      Dictionary<Stats, float> baseStats = InitStats.EmptyStatDictionary()
        .With(x => x[Stats.Speed] = 2)
        .With(x => x[Stats.MaxHp] = 100);

      return CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .AddWorldPosition(at)
        .AddBaseStats(baseStats)
        .AddStatModifiers(InitStats.EmptyStatDictionary())
        .AddDirection(Vector2.zero)
        .AddSpeed(baseStats[Stats.Speed])
        .AddCurrentHp(baseStats[Stats.MaxHp])
        .AddMaxHp(baseStats[Stats.MaxHp])
        .AddViewAddress(AssetAddress.Hero)
        .With(x => x.isHero = true)
        .With(x => x.isTurnedAlongDirection = true)
        .With(x => x.isMovementAvailable = true);
    }
  }
}