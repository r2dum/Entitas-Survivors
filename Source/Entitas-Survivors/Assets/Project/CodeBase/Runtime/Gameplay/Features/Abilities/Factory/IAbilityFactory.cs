namespace CodeBase.Runtime.Gameplay.Features.Abilities.Factory
{
  public interface IAbilityFactory
  {
    GameEntity CreateVegetableBoltAbility(int level);
    GameEntity CreateRadialEnergyOrbAbility(int level);
    GameEntity CreateOrbitingMushroomAbility(int level);
    GameEntity CreateBouncingRuneStoneAbility(int level);
    GameEntity CreateDragonFruitAbility(int level);
    GameEntity CreateScatteringFireBallAbility(int level);
    GameEntity CreateGarlicAuraAbility();
    GameEntity CreateHealAuraAbility(int producerId);
    GameEntity CreateSpeedUpAuraAbility(int producerId);
  }
}