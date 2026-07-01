using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Armaments.Systems
{
  public class MarkProcessedOnTargetPierceLimitExceededSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _armaments;

    public MarkProcessedOnTargetPierceLimitExceededSystem(GameContext gameContext)
    {
      _armaments = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament,
          GameMatcher.TargetPierceLimit,
          GameMatcher.ProcessedTargets));
    }

    public void Execute()
    {
      foreach (GameEntity armament in _armaments)
        if (armament.ProcessedTargets.Count >= armament.TargetPierceLimit)
          armament.isProcessed = true;
    }
  }
}