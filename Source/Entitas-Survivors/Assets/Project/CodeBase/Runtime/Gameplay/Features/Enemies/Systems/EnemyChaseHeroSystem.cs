using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Systems
{
  public class EnemyChaseHeroSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _enemies;
    private readonly IGroup<GameEntity> _heroes;

    public EnemyChaseHeroSystem(GameContext gameContext)
    {
      _enemies = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Enemy,
          GameMatcher.WorldPosition));

      _heroes = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _heroes)
      foreach (GameEntity enemy in _enemies)
      {
        enemy.ReplaceDirection((hero.WorldPosition - enemy.WorldPosition).normalized);
        enemy.isMoving = true;
      }
    }
  }
}