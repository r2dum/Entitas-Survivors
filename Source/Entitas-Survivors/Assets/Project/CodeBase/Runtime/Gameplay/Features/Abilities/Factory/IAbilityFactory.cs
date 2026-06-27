namespace CodeBase.Runtime.Gameplay.Features.Abilities.Factory
{
  public interface IAbilityFactory
  {
    GameEntity CreateVegetableBoltAbility(int level);
    GameEntity CreateEnergyOrb(int level);
    GameEntity CreateOrbitingMushroomAbility(int level);
    GameEntity CreateBouncingHummerAbility(int level);
    GameEntity CreateGarlicAuraAbility();
  }
}