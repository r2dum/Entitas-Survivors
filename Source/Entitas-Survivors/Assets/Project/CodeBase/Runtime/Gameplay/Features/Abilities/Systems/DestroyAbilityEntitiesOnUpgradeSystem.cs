using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Abilities.Systems
{
  public class DestroyAbilityEntitiesOnUpgradeSystem : IExecuteSystem
  {
    private readonly GameContext _gameContext;

    private readonly IGroup<GameEntity> _abilities;
    private readonly IGroup<GameEntity> _upgradeRequests;

    public DestroyAbilityEntitiesOnUpgradeSystem(GameContext gameContext)
    {
      _gameContext = gameContext;

      _abilities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.AbilityId,
          GameMatcher.RecreatedOnUpgrade));

      _upgradeRequests = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.UpgradeRequest,
          GameMatcher.AbilityId));
    }

    public void Execute()
    {
      foreach (GameEntity upgradeRequest in _upgradeRequests)
      foreach (GameEntity ability in _abilities)
      {
        if (upgradeRequest.AbilityId == ability.AbilityId)
        {
          foreach (GameEntity entity in _gameContext.GetEntitiesWithParentAbility(ability.AbilityId))
            entity.isDestructed = true;

          ability.isActive = false;
        }
      }
    }
  }
}