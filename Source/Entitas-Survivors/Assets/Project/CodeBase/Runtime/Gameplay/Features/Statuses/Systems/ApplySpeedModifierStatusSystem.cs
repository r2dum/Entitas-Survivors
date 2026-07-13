using System.Collections.Generic;
using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Gameplay.Features.CharacterStats;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Statuses.Systems
{
  public class ApplySpeedModifierStatusSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _statuses;
    private readonly List<GameEntity> _buffer = new(32);

    public ApplySpeedModifierStatusSystem(GameContext gameContext)
    {
      _statuses = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Id,
          GameMatcher.Status,
          GameMatcher.SpeedModifier,
          GameMatcher.ProducerId,
          GameMatcher.TargetId,
          GameMatcher.EffectValue)
        .NoneOf(GameMatcher.Affected));
    }

    public void Execute()
    {
      foreach (GameEntity status in _statuses.GetEntities(_buffer))
      {
        CreateEntity.Empty()
          .AddStatChange(Stats.Speed)
          .AddTargetId(status.TargetId)
          .AddProducerId(status.ProducerId)
          .AddEffectValue(status.EffectValue)
          .AddApplierStatusLink(status.Id);

        status.isAffected = true;
      }
    }
  }
}