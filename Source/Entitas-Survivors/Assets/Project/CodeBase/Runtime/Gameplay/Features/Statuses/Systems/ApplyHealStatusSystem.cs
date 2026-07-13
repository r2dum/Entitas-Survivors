using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Features.Effects;
using CodeBase.Runtime.Gameplay.Features.Effects.Factory;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Statuses.Systems
{
  public class ApplyHealStatusSystem : IExecuteSystem
  {
    private readonly IEffectFactory _effectFactory;

    private readonly IGroup<GameEntity> _statuses;
    private readonly List<GameEntity> _buffer = new(32);

    public ApplyHealStatusSystem(GameContext gameContext, IEffectFactory effectFactory)
    {
      _effectFactory = effectFactory;

      _statuses = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Heal,
          GameMatcher.Status,
          GameMatcher.ProducerId,
          GameMatcher.TargetId,
          GameMatcher.EffectValue)
        .NoneOf(GameMatcher.Affected));
    }

    public void Execute()
    {
      foreach (GameEntity status in _statuses.GetEntities(_buffer))
      {
        _effectFactory.CreateEffect(new EffectSetup
          {
            EffectTypeId = EffectTypeId.Heal,
            Value = status.EffectValue
          },
          status.ProducerId,
          status.TargetId);

        status.isAffected = true;
      }
    }
  }
}