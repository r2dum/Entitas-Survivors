using CodeBase.Runtime.Common;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Gameplay.Core.Physics;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Loot.Systems
{
  public class CastForPullablesSystem : IExecuteSystem
  {
    private readonly IPhysicsService _physicsService;

    private readonly IGroup<GameEntity> _looters;

    private readonly GameEntity[] _hitBuffer = new GameEntity[128];

    public CastForPullablesSystem(GameContext gameContext, IPhysicsService physicsService)
    {
      _physicsService = physicsService;

      _looters = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.WorldPosition,
          GameMatcher.PickupRadius));
    }

    public void Execute()
    {
      foreach (GameEntity looter in _looters)
      {
        for (int i = 0; i < LootInRadius(looter); i++)
        {
          if (_hitBuffer[i].isPullable)
          {
            _hitBuffer[i].isPullable = false;
            _hitBuffer[i].isPulling = true;
          }
        }

        ClearHitBuffer();
      }
    }

    private void ClearHitBuffer()
    {
      for (int i = 0; i < _hitBuffer.Length; i++)
        _hitBuffer[i] = null;
    }

    private int LootInRadius(GameEntity looter) =>
      _physicsService.CircleCast(looter.WorldPosition, looter.PickupRadius, CollisionLayer.Collectable.AsMask(), _hitBuffer);
  }
}