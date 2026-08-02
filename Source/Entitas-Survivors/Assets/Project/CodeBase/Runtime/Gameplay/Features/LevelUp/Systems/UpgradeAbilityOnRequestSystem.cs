using CodeBase.Runtime.Gameplay.Features.Abilities.Upgrade;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.LevelUp.Systems
{
  public class UpgradeAbilityOnRequestSystem : IExecuteSystem
  {
    private readonly IAbilityUpgradeService _abilityUpgradeService;

    private readonly IGroup<GameEntity> _levelUps;
    private readonly IGroup<GameEntity> _upgradeRequests;

    public UpgradeAbilityOnRequestSystem(GameContext gameContext, IAbilityUpgradeService abilityUpgradeService)
    {
      _abilityUpgradeService = abilityUpgradeService;

      _levelUps = gameContext.GetGroup(GameMatcher.LevelUp);

      _upgradeRequests = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.AbilityId,
          GameMatcher.UpgradeRequest));
    }

    public void Execute()
    {
      foreach (GameEntity upgradeRequest in _upgradeRequests)
      foreach (GameEntity levelUp in _levelUps)
      {
        _abilityUpgradeService.UpgradeAbility(upgradeRequest.AbilityId);

        levelUp.isProcessed = true;
        upgradeRequest.isDestructed = true;
      }
    }
  }
}