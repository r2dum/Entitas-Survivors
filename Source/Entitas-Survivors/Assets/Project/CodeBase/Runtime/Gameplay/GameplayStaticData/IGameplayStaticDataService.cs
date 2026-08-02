using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Features.Abilities;
using CodeBase.Runtime.Gameplay.Features.Abilities.Configs;
using CodeBase.Runtime.Gameplay.Features.Enchants;
using CodeBase.Runtime.Gameplay.Features.Enemies;
using CodeBase.Runtime.Gameplay.Features.Enemies.Configs;
using CodeBase.Runtime.Gameplay.Features.Loot;
using CodeBase.Runtime.Gameplay.Features.Loot.Configs;
using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Gameplay.GameplayStaticData
{
  public interface IGameplayStaticDataService
  {
    UniTask LoadAllAsync();
    AbilityConfig GetAbilityConfig(AbilityId abilityId);
    AbilityLevel GetAbilityLevel(AbilityId abilityId, int level);
    EnchantConfig GetEnchantConfig(EnchantTypeId typeId);
    EnemyConfig GetEnemyConfig(EnemyTypeId typeId);
    List<EnemyConfig> GetEnemyConfigs();
    LootConfig GetLootConfig(LootTypeId typeId);
    List<AbilityId> GetHeroUpgradableAbilityIds();
    WavesConfig GetWavesConfig();
    int MaxLevel();
    float ExperienceForLevel(int level);
  }
}