using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Runtime.Common;
using CodeBase.Runtime.Infrastructure.AssetManagement;
using CodeBase.Runtime.Meta.Features.AfkGain.Configs;
using CodeBase.Runtime.UI.Windows;
using CodeBase.Runtime.UI.Windows.Configs;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace CodeBase.Runtime.Services.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private readonly IAssetProvider _assetProvider;

    private Dictionary<WindowTypeId, AssetReference> _windowPrefabsById;

    private AfkGainConfig _afkGainConfig;

    public StaticDataService(IAssetProvider assetProvider) =>
      _assetProvider = assetProvider;

    public async UniTask LoadAllAsync()
    {
      await LoadWindows();
      await LoadAfkGainConfig();
    }

    public AssetReference GetWindowReference(WindowTypeId typeId)
    {
      if (_windowPrefabsById.TryGetValue(typeId, out AssetReference config))
        return config;

      throw new Exception($"Reference config for window {typeId} was not found");
    }

    public AfkGainConfig GetAfkGainConfig() =>
      _afkGainConfig;

    private async UniTask LoadWindows()
    {
      WindowsConfig windowsConfig = await _assetProvider.Load<WindowsConfig>(AssetAddress.WindowsConfig);
      _windowPrefabsById = windowsConfig.WindowConfigs.ToDictionary(c => c.TypeId, c => c.Reference);
    }

    private async UniTask LoadAfkGainConfig() =>
      _afkGainConfig = await _assetProvider.Load<AfkGainConfig>(AssetAddress.AfkGainConfig);
  }
}