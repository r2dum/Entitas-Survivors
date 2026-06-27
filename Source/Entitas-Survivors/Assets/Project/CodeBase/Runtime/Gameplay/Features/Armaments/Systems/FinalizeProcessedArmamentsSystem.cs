using CodeBase.Runtime.Gameplay.Features.TargetCollection;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Armaments.Systems
{
  public class FinalizeProcessedArmamentsSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _armaments;

    public FinalizeProcessedArmamentsSystem(GameContext gameContext)
    {
      _armaments = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament,
          GameMatcher.Processed));
    }

    public void Execute()
    {
      foreach (GameEntity armament in _armaments)
      {
        armament.RemoveTargetCollectionComponents();
        armament.isDestructed = true;
      }
    }
  }
}