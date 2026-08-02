using CodeBase.Runtime.Gameplay.Core;
using Entitas;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Armaments.Systems
{
  public class RedirectBouncingArmamentToNextTargetSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _armaments;
    private readonly IGroup<GameEntity> _enemies;

    public RedirectBouncingArmamentToNextTargetSystem(GameContext gameContext)
    {
      _armaments = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament,
          GameMatcher.WorldPosition,
          GameMatcher.TargetBounceLimit,
          GameMatcher.TargetBuffer,
          GameMatcher.ProcessedTargets));

      _enemies = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Enemy,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity armament in _armaments)
      {
        if (armament.TargetBuffer.Count == 0)
          continue;

        if (armament.ProcessedTargets.Count > armament.TargetBounceLimit)
          continue;

        Vector3 hitEnemyPosition = LastHitEnemyPosition(armament);
        GameEntity nearestEnemy = _enemies.GetNearestExcept(hitEnemyPosition, armament.ProcessedTargets);

        if (nearestEnemy != null)
          armament.ReplaceDirection((nearestEnemy.WorldPosition - armament.WorldPosition).normalized);
      }
    }

    private Vector3 LastHitEnemyPosition(GameEntity armament)
    {
      int lastHitEnemyId = armament.TargetBuffer[^1];

      foreach (GameEntity enemy in _enemies)
        if (enemy.Id == lastHitEnemyId)
          return enemy.WorldPosition;

      return armament.WorldPosition;
    }
  }
}