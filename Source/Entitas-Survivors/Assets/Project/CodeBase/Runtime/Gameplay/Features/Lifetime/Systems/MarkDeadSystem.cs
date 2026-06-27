using System.Collections.Generic;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Lifetime.Systems
{
  public class MarkDeadSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(128);

    public MarkDeadSystem(GameContext gameContext)
    {
      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.CurrentHp,
          GameMatcher.MaxHp)
        .NoneOf(GameMatcher.Dead));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        if (entity.CurrentHp <= 0)
        {
          entity.isDead = true;
          entity.isProcessingDeath = true;
        }
      }
    }
  }
}