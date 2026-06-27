using CodeBase.Runtime.Gameplay.Core.Time;
using Entitas;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Movement.Systems
{
  public class DirectionalDeltaMoveSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _movers;
    private readonly ITimeService _timeService;

    public DirectionalDeltaMoveSystem(GameContext gameContext, ITimeService timeService)
    {
      _timeService = timeService;
      _movers = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Direction,
          GameMatcher.WorldPosition,
          GameMatcher.Speed,
          GameMatcher.MovementAvailable,
          GameMatcher.Moving));
    }

    public void Execute()
    {
      foreach (GameEntity mover in _movers)
        mover.ReplaceWorldPosition((Vector2)mover.WorldPosition + mover.Direction * mover.Speed * _timeService.DeltaTime);
    }
  }
}