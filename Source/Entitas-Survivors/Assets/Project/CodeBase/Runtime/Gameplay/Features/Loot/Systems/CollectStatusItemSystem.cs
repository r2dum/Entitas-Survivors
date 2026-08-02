using CodeBase.Runtime.Gameplay.Features.Statuses;
using CodeBase.Runtime.Gameplay.Features.Statuses.Applier;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Loot.Systems
{
  public class CollectStatusItemSystem : IExecuteSystem
  {
    private readonly IStatusApplier _statusApplier;

    private readonly IGroup<GameEntity> _heroes;
    private readonly IGroup<GameEntity> _collected;

    public CollectStatusItemSystem(GameContext gameContext, IStatusApplier statusApplier)
    {
      _statusApplier = statusApplier;

      _heroes = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Id,
          GameMatcher.Hero,
          GameMatcher.WorldPosition));

      _collected = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Collected,
          GameMatcher.StatusSetups));
    }

    public void Execute()
    {
      foreach (GameEntity collected in _collected)
      foreach (GameEntity hero in _heroes)
      foreach (StatusSetup statusSetup in collected.StatusSetups)
        _statusApplier.ApplyStatus(statusSetup, hero.Id, hero.Id);
    }
  }
}