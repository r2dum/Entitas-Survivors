using CodeBase.Runtime.Gameplay.Features.Abilities;
using CodeBase.Runtime.Gameplay.Features.Abilities.Upgrade;
using CodeBase.Runtime.Gameplay.Features.Hero.Factory;
using CodeBase.Runtime.Gameplay.Levels;
using CodeBase.Runtime.Gameplay.Levels.Providers;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Hero.Systems
{
  public class InitializeHeroSystem : IInitializeSystem
  {
    private readonly IHeroFactory _heroFactory;
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly IAbilityUpgradeService _abilityUpgradeService;

    public InitializeHeroSystem(IHeroFactory heroFactory, ILevelDataProvider levelDataProvider,
      IAbilityUpgradeService abilityUpgradeService)
    {
      _heroFactory = heroFactory;
      _levelDataProvider = levelDataProvider;
      _abilityUpgradeService = abilityUpgradeService;
    }

    public void Initialize()
    {
      _heroFactory.CreateHero(_levelDataProvider.StartPoint);
      _abilityUpgradeService.InitializeAbility(AbilityId.VegetableBolt);
    }
  }
}