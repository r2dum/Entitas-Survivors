using CodeBase.Runtime.Gameplay.Core.Time;
using Entitas;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Movement.Systems
{
  public class OrbitalDeltaMoveSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _movers;
    private readonly ITimeService _timeService;

    public OrbitalDeltaMoveSystem(GameContext gameContext, ITimeService timeService)
    {
      _timeService = timeService;
      _movers = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.OrbitPhase,
          GameMatcher.OrbitCenterPosition,
          GameMatcher.OrbitRadius,
          GameMatcher.WorldPosition,
          GameMatcher.Speed,
          GameMatcher.MovementAvailable,
          GameMatcher.Moving));
    }

    public void Execute()
    {
      foreach (GameEntity mover in _movers)
      {
        float phase = mover.OrbitPhase + _timeService.DeltaTime * mover.Speed;
        mover.ReplaceOrbitPhase(phase);

        Vector3 newRelativePosition = new(Mathf.Cos(phase) * mover.OrbitRadius, Mathf.Sin(phase) * mover.OrbitRadius, 0f);
        Vector3 newPosition = newRelativePosition + mover.OrbitCenterPosition;

        mover.ReplaceWorldPosition(newPosition);
      }
    }
  }

}