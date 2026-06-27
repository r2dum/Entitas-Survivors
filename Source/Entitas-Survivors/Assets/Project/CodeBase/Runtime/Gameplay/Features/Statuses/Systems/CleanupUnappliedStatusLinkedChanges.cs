using System.Collections.Generic;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Statuses.Systems
{
  public class CleanupUnappliedStatusLinkedChanges : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _statuses;
    private readonly List<GameEntity> _buffer = new(32);
    private readonly GameContext _gameContext;

    public CleanupUnappliedStatusLinkedChanges(GameContext gameContext)
    {
      _gameContext = gameContext;
      _statuses = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Id,
          GameMatcher.Status,
          GameMatcher.Unapplied));
    }

    public void Cleanup()
    {
      foreach (GameEntity status in _statuses.GetEntities(_buffer))
      foreach (GameEntity entity in _gameContext.GetEntitiesWithApplierStatusLink(status.Id))
        entity.isDestructed = true;
    }
  }
}