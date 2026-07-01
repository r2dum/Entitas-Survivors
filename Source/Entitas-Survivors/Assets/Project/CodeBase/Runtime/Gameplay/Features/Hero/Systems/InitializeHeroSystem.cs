using CodeBase.Runtime.Gameplay.Features.Abilities.Factory;
using CodeBase.Runtime.Gameplay.Features.Hero.Factory;
using CodeBase.Runtime.Gameplay.Features.Statuses;
using CodeBase.Runtime.Gameplay.Features.Statuses.Applier;
using CodeBase.Runtime.Gameplay.Levels;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Hero.Systems
{
  public class InitializeHeroSystem : IInitializeSystem
  {
    private readonly IHeroFactory _heroFactory;
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly IAbilityFactory _abilityFactory;
    private readonly IStatusApplier _statusApplier;

    public InitializeHeroSystem(IHeroFactory heroFactory, ILevelDataProvider levelDataProvider,
      IAbilityFactory abilityFactory, IStatusApplier statusApplier)
    {
      _heroFactory = heroFactory;
      _levelDataProvider = levelDataProvider;
      _abilityFactory = abilityFactory;
      _statusApplier = statusApplier;
    }

    public void Initialize()
    {
      GameEntity hero = _heroFactory.CreateHero(_levelDataProvider.StartPoint);
      //_abilityFactory.CreateVegetableBoltAbility(level: 1);
      _abilityFactory.CreateBouncingRuneStoneAbility(level: 1);
      _abilityFactory.CreateScatteringFireBallAbility(level: 1);
      _abilityFactory.CreateGarlicAuraAbility();
      //_abilityFactory.CreateEnergyOrb(level: 1);

      /*_statusApplier.ApplyStatus(new StatusSetup
      {
        StatusTypeId = StatusTypeId.PoisonEnchant,
        Duration = 10
      }, hero.Id, hero.Id);*/

      _statusApplier.ApplyStatus(new StatusSetup
      {
        StatusTypeId = StatusTypeId.ExplosiveEnchant,
        Duration = 50
      }, hero.Id, hero.Id);
    }
  }
}