using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.TargetCollection.Systems
{
  public class CleanupTargetBuffersSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _entities;

    public CleanupTargetBuffersSystem(GameContext gameContext) =>
      _entities = gameContext.GetGroup(GameMatcher.TargetBuffer);

    public void Cleanup()
    {
      foreach (GameEntity entity in _entities)
        entity.TargetBuffer.Clear();
    }
  }
}