using System.Collections.Generic;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Statuses.Systems
{
  public class UnapplyAffectedStatusesWithoutDurationSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _statuses;
    private readonly List<GameEntity> _buffer = new(32);

    public UnapplyAffectedStatusesWithoutDurationSystem(GameContext gameContext)
    {
      _statuses = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Status,
          GameMatcher.Affected)
        .NoneOf(GameMatcher.Duration));
    }

    public void Execute()
    {
      foreach (GameEntity status in _statuses.GetEntities(_buffer))
        status.isUnapplied = true;
    }
  }
}