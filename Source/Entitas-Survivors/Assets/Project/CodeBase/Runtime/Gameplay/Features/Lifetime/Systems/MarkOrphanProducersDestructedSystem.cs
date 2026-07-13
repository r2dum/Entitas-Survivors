using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Core;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Lifetime.Systems
{
  public class MarkOrphanProducersDestructedSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _entitiesWithProducer;
    private readonly List<GameEntity> _buffer = new(128);

    public MarkOrphanProducersDestructedSystem(GameContext gameContext) =>
      _entitiesWithProducer = gameContext.GetGroup(GameMatcher.ProducerId);

    public void Cleanup()
    {
      foreach (GameEntity entity in _entitiesWithProducer.GetEntities(_buffer))
      {
        if (entity.isDestructed)
          continue;

        GameEntity producer = entity.Producer();

        if (producer == null || producer.isDead)
          entity.isDestructed = true;
      }
    }
  }
}