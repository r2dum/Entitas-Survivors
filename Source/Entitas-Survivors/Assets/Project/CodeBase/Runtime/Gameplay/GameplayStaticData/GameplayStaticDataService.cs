using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Runtime.Common;
using CodeBase.Runtime.Gameplay.Features.Abilities;
using CodeBase.Runtime.Gameplay.Features.Abilities.Configs;
using CodeBase.Runtime.Gameplay.Features.Enchants;
using CodeBase.Runtime.Gameplay.Features.Enemies;
using CodeBase.Runtime.Gameplay.Features.Enemies.Configs;
using CodeBase.Runtime.Gameplay.Features.LevelUp.Configs;
using CodeBase.Runtime.Gameplay.Features.Loot;
using CodeBase.Runtime.Gameplay.Features.Loot.Configs;
using CodeBase.Runtime.Infrastructure.AssetManagement;
using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Gameplay.GameplayStaticData
{
  public class GameplayStaticDataService : IGameplayStaticDataService
  {
    private readonly IAssetProvider _assetProvider;

    private Dictionary<LootTypeId, LootConfig> _lootById;
    private Dictionary<EnemyTypeId, EnemyConfig> _enemyById;
    private Dictionary<AbilityId, AbilityConfig> _abilityById;
    private Dictionary<EnchantTypeId, EnchantConfig> _enchantById;

    private LevelUpConfig _levelUpConfig;
    private WavesConfig _wavesConfig;

    public GameplayStaticDataService(IAssetProvider assetProvider) =>
      _assetProvider = assetProvider;

    public async UniTask LoadAllAsync()
    {
      await LoadAbilities();
      await LoadEnchants();
      await LoadEnemies();
      await LoadLoot();
      await LoadLevelUpConfig();
      await LoadWavesConfig();
    }

    public AbilityConfig GetAbilityConfig(AbilityId abilityId)
    {
      if (_abilityById.TryGetValue(abilityId, out AbilityConfig config))
        return config;

      throw new Exception($"Ability config for {abilityId} was not found");
    }

    public AbilityLevel GetAbilityLevel(AbilityId abilityId, int level)
    {
      AbilityConfig config = GetAbilityConfig(abilityId);

      if (level > config.Levels.Count)
        level = config.Levels.Count;

      return config.Levels[level - 1];
    }

    public EnchantConfig GetEnchantConfig(EnchantTypeId typeId)
    {
      if (_enchantById.TryGetValue(typeId, out EnchantConfig config))
        return config;

      throw new Exception($"Enchant config for {typeId} was not found");
    }

    public EnemyConfig GetEnemyConfig(EnemyTypeId typeId)
    {
      if (_enemyById.TryGetValue(typeId, out EnemyConfig config))
        return config;

      throw new Exception($"Enemy config for {typeId} was not found");
    }

    public List<EnemyConfig> GetEnemyConfigs()
    {
      if (_enemyById.Count > 0)
        return new List<EnemyConfig>(_enemyById.Values);

      throw new Exception("Enemy configs was not found");
    }

    public LootConfig GetLootConfig(LootTypeId typeId)
    {
      if (_lootById.TryGetValue(typeId, out LootConfig config))
        return config;

      throw new Exception($"Loot config for {typeId} was not found");
    }

    public List<AbilityId> GetHeroUpgradableAbilityIds() =>
      _abilityById.Values
        .Where(config => config.OwnerTypeId is OwnerTypeId.Hero or OwnerTypeId.Shared)
        .Select(config => config.AbilityId)
        .ToList();

    public WavesConfig GetWavesConfig() =>
      _wavesConfig;

    public int MaxLevel() =>
      _levelUpConfig.MaxLevel;

    public float ExperienceForLevel(int level) =>
      _levelUpConfig.ExperienceForLevel[level];

    private async UniTask LoadEnemies()
    {
      EnemyConfig[] enemyConfigs = await GetConfigs<EnemyConfig>(AssetLabel.EnemyConfig);
      _enemyById = enemyConfigs.ToDictionary(c => c.TypeId, c => c);
    }

    private async UniTask LoadAbilities()
    {
      AbilityConfig[] abilityConfigs = await GetConfigs<AbilityConfig>(AssetLabel.AbilityConfig);
      _abilityById = abilityConfigs.ToDictionary(c => c.AbilityId, c => c);
    }

    private async UniTask LoadEnchants()
    {
      EnchantConfig[] enchantConfigs = await GetConfigs<EnchantConfig>(AssetLabel.EnchantConfig);
      _enchantById = enchantConfigs.ToDictionary(c => c.TypeId, c => c);
    }

    private async UniTask LoadLoot()
    {
      LootConfig[] lootConfigs = await GetConfigs<LootConfig>(AssetLabel.LootConfig);
      _lootById = lootConfigs.ToDictionary(c => c.TypeId, c => c);
    }

    private async UniTask LoadLevelUpConfig() =>
      _levelUpConfig = await _assetProvider.Load<LevelUpConfig>(AssetAddress.LevelUpConfig);

    private async UniTask LoadWavesConfig() =>
      _wavesConfig = await _assetProvider.Load<WavesConfig>(AssetAddress.WavesConfig);

    private async UniTask<TConfig[]> GetConfigs<TConfig>(string labelKey) where TConfig : class
    {
      List<string> keys = await _assetProvider.GetAssetsListByLabel<TConfig>(labelKey);
      return await _assetProvider.LoadAll<TConfig>(keys);
    }
  }
}