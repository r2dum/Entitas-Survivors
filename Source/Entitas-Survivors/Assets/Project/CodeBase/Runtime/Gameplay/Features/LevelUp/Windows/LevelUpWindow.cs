using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Gameplay.Features.Abilities;
using CodeBase.Runtime.Gameplay.Features.Abilities.Configs;
using CodeBase.Runtime.Gameplay.Features.Abilities.Upgrade;
using CodeBase.Runtime.Gameplay.Features.LevelUp.Behaviours;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
using CodeBase.Runtime.UI.Windows;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Features.LevelUp.Windows
{
  public class LevelUpWindow : WindowBase
  {
    [SerializeField] private RectTransform _abilityLayout;

    private IGameplayStaticDataService _staticDataService;
    private IAbilityUpgradeService _abilityUpgradeService;
    private IAbilityUIFactory _abilityUIFactory;
    private IWindowService _windowService;

    [Inject]
    private void Construct(IGameplayStaticDataService staticDataService, IAbilityUpgradeService abilityUpgradeService,
      IAbilityUIFactory abilityUIFactory, IWindowService windowService)
    {
      TypeId = WindowTypeId.LevelUpWindow;

      _staticDataService = staticDataService;
      _abilityUpgradeService = abilityUpgradeService;
      _abilityUIFactory = abilityUIFactory;
      _windowService = windowService;
    }

    protected override async void Initialize()
    {
      foreach (AbilityUpgradeOption abilityUpgradeOption in _abilityUpgradeService.GetUpgradeOptions())
      {
        AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(abilityUpgradeOption.AbilityId, abilityUpgradeOption.Level);
        AbilityCard abilityCard = await _abilityUIFactory.CreateAbilityCard(_abilityLayout);
        abilityCard.Setup(abilityUpgradeOption.AbilityId, abilityLevel, OnSelected);
      }
    }

    private void OnSelected(AbilityId abilityId)
    {
      CreateEntity.Empty()
        .AddAbilityId(abilityId)
        .isUpgradeRequest = true;

      _windowService.Close(TypeId);
    }
  }
}