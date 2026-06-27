using CodeBase.Runtime.Gameplay.Features.Abilities;
using CodeBase.Runtime.Gameplay.Features.Abilities.Configs;
using CodeBase.Runtime.Gameplay.Features.Enchants;
using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Gameplay.GameplayStaticData
{
  public interface IGameplayStaticDataService
  {
    UniTask LoadAllAsync();
    AbilityConfig GetAbilityConfig(AbilityId abilityId);
    AbilityLevel GetAbilityLevel(AbilityId abilityId, int level);
    EnchantConfig GetEnchantConfig(EnchantTypeId typeId);
  }
}