using CodeBase.Runtime.Gameplay.Features.Abilities;
using CodeBase.Runtime.Gameplay.Features.Abilities.Upgrade;
using CodeBase.Runtime.Gameplay.Features.Armaments.Factory;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Armaments.Systems
{
  public class SpawnFireOnDragonFruitDestinationReachedSystem : IExecuteSystem
  {
    private readonly IArmamentFactory _armamentFactory;
    private readonly IAbilityUpgradeService _abilityUpgradeService;

    private readonly IGroup<GameEntity> _armaments;

    public SpawnFireOnDragonFruitDestinationReachedSystem(GameContext gameContext, IArmamentFactory armamentFactory,
      IAbilityUpgradeService abilityUpgradeService)
    {
      _armamentFactory = armamentFactory;
      _abilityUpgradeService = abilityUpgradeService;

      _armaments = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament,
          GameMatcher.DragonFruitArmament,
          GameMatcher.WorldPosition,
          GameMatcher.Reached));
    }

    public void Execute()
    {
      foreach (GameEntity armament in _armaments)
      {
        int level = _abilityUpgradeService.GetAbilityLevel(AbilityId.DragonFruit);
        _armamentFactory.CreateDragonFruitFirePuddle(level, armament.WorldPosition);
      }
    }
  }
}