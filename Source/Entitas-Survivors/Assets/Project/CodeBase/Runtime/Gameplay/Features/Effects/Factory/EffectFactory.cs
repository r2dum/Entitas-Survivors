using System;
using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Infrastructure.Identifiers;

namespace CodeBase.Runtime.Gameplay.Features.Effects.Factory
{
  public class EffectFactory : IEffectFactory
  {
    private readonly IIdentifierService _identifierService;

    public EffectFactory(IIdentifierService identifierService) =>
      _identifierService = identifierService;

    public GameEntity CreateEffect(EffectSetup setup, int producerId, int targetId)
    {
      switch (setup.EffectTypeId)
      {
        case EffectTypeId.Unknown:
          break;
        case EffectTypeId.Damage:
          return CreateDamage(producerId, targetId, setup.Value);
        case EffectTypeId.Heal:
          return CreateHeal(producerId, targetId, setup.Value);
      }

      throw new Exception($"Effect with type id {setup.EffectTypeId} does not exist");
    }

    private GameEntity CreateDamage(int producerId, int targetId, float value)
    {
      return CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .With(x => x.isEffect = true)
        .With(x => x.isDamageEffect = true)
        .AddEffectValue(value)
        .AddProducerId(producerId)
        .AddTargetId(targetId);
    }
    
    private GameEntity CreateHeal(int producerId, int targetId, float value)
    {
      return CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .With(x => x.isEffect = true)
        .With(x => x.isHealEffect = true)
        .AddEffectValue(value)
        .AddProducerId(producerId)
        .AddTargetId(targetId);
    }
  }
}