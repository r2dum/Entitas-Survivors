using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Runtime.Common.Randoms;
using CodeBase.Runtime.Gameplay.Features.Abilities.Configs;
using CodeBase.Runtime.Gameplay.Features.Abilities.Factory;
using CodeBase.Runtime.Gameplay.GameplayStaticData;

namespace CodeBase.Runtime.Gameplay.Features.Abilities.Upgrade
{
  public class AbilityUpgradeService : IAbilityUpgradeService
  {
    private const int MinRepeatedAbilitiesToOffer = 1;
    private const int MaxCardsToOffer = 2;

    private readonly Dictionary<AbilityId, int> _currentAbilities;

    private readonly IGameplayStaticDataService _staticDataService;
    private readonly IRandomService _randomService;
    private readonly IAbilityFactory _abilityFactory;

    public AbilityUpgradeService(IGameplayStaticDataService staticDataService, IRandomService randomService,
      IAbilityFactory abilityFactory)
    {
      _currentAbilities = new Dictionary<AbilityId, int>();

      _staticDataService = staticDataService;
      _randomService = randomService;
      _abilityFactory = abilityFactory;
    }

    public int GetAbilityLevel(AbilityId abilityId) =>
      _currentAbilities.GetValueOrDefault(abilityId, 0);

    public void InitializeAbility(AbilityId abilityId)
    {
      if (_currentAbilities.TryAdd(abilityId, 1) == false)
        throw new Exception($"Ability {abilityId} is already initialized");

      switch (abilityId)
      {
        case AbilityId.VegetableBolt:
          _abilityFactory.CreateVegetableBoltAbility(level: 1);
          break;
        case AbilityId.GarlicAura:
          _abilityFactory.CreateGarlicAuraAbility();
          break;
        case AbilityId.OrbitingMushroom:
          _abilityFactory.CreateOrbitingMushroomAbility(level: 1);
          break;
        case AbilityId.RadialEnergyOrb:
          _abilityFactory.CreateRadialEnergyOrbAbility(level: 1);
          break;
        case AbilityId.BouncingRuneStone:
          _abilityFactory.CreateBouncingRuneStoneAbility(level: 1);
          break;
        case AbilityId.DragonFruit:
          _abilityFactory.CreateDragonFruitAbility(level: 1);
          break;
        case AbilityId.ScatteringFireBall:
          _abilityFactory.CreateScatteringFireBallAbility(level: 1);
          break;
        default:
          throw new Exception($"Ability {abilityId} is not defined");
      }
    }

    public void UpgradeAbility(AbilityId abilityId)
    {
      if (_currentAbilities.ContainsKey(abilityId))
        _currentAbilities[abilityId]++;
      else
        InitializeAbility(abilityId);
    }

    public List<AbilityUpgradeOption> GetUpgradeOptions()
    {
      List<AbilityUpgradeOption> upgradeOptions = new();

      int targetRepeatedCount = MinRepeatedAbilitiesToOffer + _randomService.Range(0, Math.Min(_currentAbilities.Count, MaxCardsToOffer));

      upgradeOptions.AddRange(GetRandomRepeatedAbilities(targetRepeatedCount));

      int missingCardsCount = MaxCardsToOffer - upgradeOptions.Count;
      if (missingCardsCount > 0)
        upgradeOptions.AddRange(GetRandomUntappedAbilities(missingCardsCount));

      return upgradeOptions;
    }

    private List<AbilityUpgradeOption> GetRandomRepeatedAbilities(int count) =>
      _currentAbilities.Keys
        .Where(abilityId => _currentAbilities[abilityId] < GetMaxAbilityLevel(abilityId))
        .OrderBy(_ => _randomService.Range(0, _currentAbilities.Count))
        .Take(count)
        .Select(abilityId => new AbilityUpgradeOption
        {
          AbilityId = abilityId,
          Level = _currentAbilities[abilityId] + 1
        })
        .ToList();

    private List<AbilityUpgradeOption> GetRandomUntappedAbilities(int count) =>
      UnacquiredAbilities()
        .OrderBy(_ => _randomService.Range(0, UnacquiredAbilities().Count))
        .Take(count)
        .Select(abilityId => new AbilityUpgradeOption
        {
          AbilityId = abilityId,
          Level = 1
        })
        .ToList();

    private List<AbilityId> UnacquiredAbilities() =>
      _staticDataService
        .GetHeroUpgradableAbilityIds()
        .Except(_currentAbilities.Keys)
        .Where(abilityId => GetMaxAbilityLevel(abilityId) > 0)
        .ToList();

    private int GetMaxAbilityLevel(AbilityId abilityId)
    {
      AbilityConfig abilityConfig = _staticDataService.GetAbilityConfig(abilityId);
      return abilityConfig.Levels.Count;
    }

    public void Cleanup() =>
      _currentAbilities.Clear();
  }
}