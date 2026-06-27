using System.Collections.Generic;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Hero.Systems
{
  public class FinalizeHeroDeathProcessingSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _heroes;
    private readonly List<GameEntity> _buffer = new(1);

    public FinalizeHeroDeathProcessingSystem(GameContext gameContext)
    {
      _heroes = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.Dead,
          GameMatcher.ProcessingDeath));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _heroes.GetEntities(_buffer))
        hero.isProcessingDeath = false;
    }
  }
}