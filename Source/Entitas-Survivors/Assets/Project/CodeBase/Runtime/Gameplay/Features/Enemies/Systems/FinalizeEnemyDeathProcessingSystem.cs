using System.Collections.Generic;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Systems
{
  public class FinalizeEnemyDeathProcessingSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _enemies;
    private readonly List<GameEntity> _buffer = new(128);

    public FinalizeEnemyDeathProcessingSystem(GameContext gameContext)
    {
      _enemies = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Enemy,
          GameMatcher.Dead,
          GameMatcher.ProcessingDeath));
    }

    public void Execute()
    {
      foreach (GameEntity enemy in _enemies.GetEntities(_buffer))
        enemy.isProcessingDeath = false;
    }
  }
}