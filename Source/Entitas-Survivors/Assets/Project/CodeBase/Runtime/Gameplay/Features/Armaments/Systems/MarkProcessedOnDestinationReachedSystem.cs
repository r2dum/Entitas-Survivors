using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Armaments.Systems
{
  public class MarkProcessedOnDestinationReachedSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _armaments;

    public MarkProcessedOnDestinationReachedSystem(GameContext gameContext)
    {
      _armaments = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament,
          GameMatcher.Destination,
          GameMatcher.Reached));
    }

    public void Execute()
    {
      foreach (GameEntity armament in _armaments)
        armament.isProcessed = true;
    }
  }
}