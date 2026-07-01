namespace CodeBase.Runtime.Gameplay.Features.Abilities.Factory
{
  public interface IAbilityFactory
  {
    GameEntity CreateVegetableBoltAbility(int level);
    GameEntity CreateRadialEnergyOrb(int level);
    GameEntity CreateOrbitingMushroomAbility(int level);
    GameEntity CreateBouncingRuneStoneAbility(int level);
    GameEntity CreateScatteringFireBallAbility(int level);
    GameEntity CreateGarlicAuraAbility();
  }
}