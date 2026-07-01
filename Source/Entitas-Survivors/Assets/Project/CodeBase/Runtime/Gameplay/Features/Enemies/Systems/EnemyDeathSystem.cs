using CodeBase.Runtime.Gameplay.Features.TargetCollection;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Systems
{
  public class EnemyDeathSystem : IExecuteSystem
  {
    private const float DeathAnimationTime = 1.5f;

    private readonly IGroup<GameEntity> _enemies;

    public EnemyDeathSystem(GameContext gameContext)
    {
      _enemies = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Enemy,
          GameMatcher.Dead,
          GameMatcher.ProcessingDeath));
    }

    public void Execute()
    {
      foreach (GameEntity enemy in _enemies)
      {
        enemy.isMovementAvailable = false;
        enemy.isTurnedAlongDirection = false;

        enemy.RemoveTargetCollectionComponents();

        if (enemy.hasView)
          enemy.View.ReleaseColliders();

        if (enemy.hasEnemyAnimator)
          enemy.EnemyAnimator.PlayDied();

        enemy.ReplaceSelfDestructTimer(DeathAnimationTime);
      }
    }
  }
}