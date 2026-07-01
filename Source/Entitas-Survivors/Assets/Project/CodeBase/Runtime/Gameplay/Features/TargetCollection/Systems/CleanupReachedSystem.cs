using System.Collections.Generic;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.TargetCollection.Systems
{
  public class CleanupReachedSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(128);

    public CleanupReachedSystem(GameContext gameContext) =>
      _entities = gameContext.GetGroup(GameMatcher.Reached);

    public void Cleanup()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
        entity.isReached = false;
    }
  }
}