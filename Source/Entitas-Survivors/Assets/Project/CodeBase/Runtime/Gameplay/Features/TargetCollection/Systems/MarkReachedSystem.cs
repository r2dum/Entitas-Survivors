using System.Collections.Generic;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.TargetCollection.Systems
{
  public class MarkReachedSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(128);

    public MarkReachedSystem(GameContext gameContext)
    {
      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(GameMatcher.TargetBuffer)
        .NoneOf(GameMatcher.Reached));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        if (entity.TargetBuffer.Count > 0)
          entity.isReached = true;
      }
    }
  }

}