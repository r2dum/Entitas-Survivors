using System.Collections.Generic;

namespace CodeBase.Runtime.Gameplay.Features.Abilities.Upgrade
{
  public interface IAbilityUpgradeService
  {
    void UpgradeAbility(AbilityId abilityId);
    void InitializeAbility(AbilityId abilityId);
    List<AbilityUpgradeOption> GetUpgradeOptions();
    int GetAbilityLevel(AbilityId abilityId);
    void Cleanup();
  }
}