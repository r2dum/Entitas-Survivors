using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Loot.Systems
{
  public class CleanupCollectedSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _collected;

    public CleanupCollectedSystem(GameContext gameContext) =>
      _collected = gameContext.GetGroup(GameMatcher.Collected);

    public void Cleanup()
    {
      foreach (GameEntity collected in _collected)
        collected.isDestructed = true;
    }
  }
}