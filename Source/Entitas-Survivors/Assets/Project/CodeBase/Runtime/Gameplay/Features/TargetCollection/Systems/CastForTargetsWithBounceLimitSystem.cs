using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Core.Physics;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.TargetCollection.Systems
{
  public class CastForTargetsWithBounceLimitSystem : IExecuteSystem, ITearDownSystem
  {
    private readonly IPhysicsService _physicsService;

    private readonly IGroup<GameEntity> _ready;
    private readonly List<GameEntity> _buffer = new(64);

    private GameEntity[] _targetCastBuffer = new GameEntity[128];

    public CastForTargetsWithBounceLimitSystem(GameContext gameContext, IPhysicsService physicsService)
    {
      _physicsService = physicsService;

      _ready = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ReadyToCollectTargets,
          GameMatcher.TargetBounceLimit,
          GameMatcher.Radius,
          GameMatcher.TargetBuffer,
          GameMatcher.ProcessedTargets,
          GameMatcher.WorldPosition,
          GameMatcher.LayerMask)
        .NoneOf(
          GameMatcher.TargetPierceLimit));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _ready.GetEntities(_buffer))
      {
        for (int i = 0; i < TargetCountInRadius(entity); i++)
        {
          int targetId = _targetCastBuffer[i].Id;

          if (AlreadyProcessed(entity, targetId) == false)
          {
            entity.TargetBuffer.Add(targetId);
            entity.ProcessedTargets.Add(targetId);
            break;
          }
        }

        if (entity.isCollectingTargetsContinuously == false)
          entity.isReadyToCollectTargets = false;
      }
    }

    public void TearDown() =>
      _targetCastBuffer = null;

    private bool AlreadyProcessed(GameEntity entity, int targetId) =>
      entity.ProcessedTargets.Contains(targetId);

    private int TargetCountInRadius(GameEntity entity) =>
      _physicsService.CircleCast(entity.WorldPosition, entity.Radius, entity.LayerMask, _targetCastBuffer);
  }
}