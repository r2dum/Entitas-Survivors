using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Armaments.Systems
{
  public class MarkProcessedOnTargetBounceLimitExceededSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _armaments;

    public MarkProcessedOnTargetBounceLimitExceededSystem(GameContext gameContext)
    {
      _armaments = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament,
          GameMatcher.TargetBounceLimit,
          GameMatcher.ProcessedTargets));
    }

    public void Execute()
    {
      foreach (GameEntity armament in _armaments)
        if (armament.ProcessedTargets.Count > armament.TargetBounceLimit)
          armament.isProcessed = true;
    }
  }
}