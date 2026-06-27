using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Runtime.Common;
using CodeBase.Runtime.Gameplay.Features.Abilities;
using CodeBase.Runtime.Gameplay.Features.Abilities.Configs;
using CodeBase.Runtime.Gameplay.Features.Enchants;
using CodeBase.Runtime.Infrastructure.AssetManagement;
using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Gameplay.GameplayStaticData
{
  public class GameplayStaticDataService : IGameplayStaticDataService
  {
    private readonly IAssetProvider _assetProvider;

    private Dictionary<AbilityId, AbilityConfig> _abilityById;
    private Dictionary<EnchantTypeId, EnchantConfig> _enchantById;

    public GameplayStaticDataService(IAssetProvider assetProvider) =>
      _assetProvider = assetProvider;

    public async UniTask LoadAllAsync()
    {
      await LoadAbilities();
      await LoadEnchants();
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

    private async UniTask<TConfig[]> GetConfigs<TConfig>(string labelKey) where TConfig : class
    {
      List<string> keys = await GetConfigKeys<TConfig>(labelKey);
      return await _assetProvider.LoadAll<TConfig>(keys);
    }

    private async UniTask<List<string>> GetConfigKeys<TConfig>(string labelKey) =>
      await _assetProvider.GetAssetsListByLabel<TConfig>(labelKey);
  }
}