using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Movement.Systems
{
  public class MarkReachedDestinationSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;

    private readonly List<GameEntity> _buffer = new(16);

    public MarkReachedDestinationSystem(GameContext gameContext)
    {
      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Destination,
          GameMatcher.WorldPosition)
        .NoneOf(GameMatcher.Reached));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
        if (Vector3.SqrMagnitude(entity.WorldPosition - entity.Destination) <= 0.1f)
          entity.isReached = true;
    }
  }
}