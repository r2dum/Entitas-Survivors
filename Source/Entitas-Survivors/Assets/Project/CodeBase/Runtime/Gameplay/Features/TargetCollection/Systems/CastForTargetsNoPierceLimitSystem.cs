using System.Collections.Generic;
using System.Linq;
using CodeBase.Runtime.Gameplay.Core.Physics;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.TargetCollection.Systems
{
  public class CastForTargetsNoPierceLimitSystem : IExecuteSystem
  {
    private readonly IPhysicsService _physicsService;

    private readonly IGroup<GameEntity> _ready;
    private readonly List<GameEntity> _buffer = new(64);

    public CastForTargetsNoPierceLimitSystem(GameContext gameContext, IPhysicsService physicsService)
    {
      _physicsService = physicsService;
      _ready = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ReadyToCollectTargets,
          GameMatcher.Radius,
          GameMatcher.TargetBuffer,
          GameMatcher.WorldPosition,
          GameMatcher.LayerMask)
        .NoneOf(
          GameMatcher.TargetPierceLimit,
          GameMatcher.TargetBounceLimit));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _ready.GetEntities(_buffer))
      {
        entity.TargetBuffer.AddRange(TargetsInRadius(entity));

        if (entity.isCollectingTargetsContinuously == false)
          entity.isReadyToCollectTargets = false;
      }
    }

    private IEnumerable<int> TargetsInRadius(GameEntity entity) =>
      _physicsService.CircleCast(entity.WorldPosition, entity.Radius, entity.LayerMask).Select(x => x.Id);
  }
}