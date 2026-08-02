using CodeBase.Runtime.Common;
using CodeBase.Runtime.Gameplay.Features.Enchants.Behaviours;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
using CodeBase.Runtime.Infrastructure.AssetManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Features.Enchants.UIFactory
{
  public class EnchantUIFactory : IEnchantUIFactory
  {
    private readonly IGameplayStaticDataService _staticDataService;
    private readonly IAssetProvider _assetProvider;
    private readonly IInstantiator _instantiator;

    public EnchantUIFactory(IGameplayStaticDataService staticDataService, IAssetProvider assetProvider, IInstantiator instantiator)
    {
      _staticDataService = staticDataService;
      _assetProvider = assetProvider;
      _instantiator = instantiator;
    }

    public async UniTask<Enchant> CreateEnchant(EnchantTypeId typeId, RectTransform parent)
    {
      EnchantConfig enchantConfig = _staticDataService.GetEnchantConfig(typeId);
      GameObject prefab = await _assetProvider.Load<GameObject>(AssetAddress.EnchantUI);
      Enchant enchant = _instantiator.InstantiatePrefabForComponent<Enchant>(prefab, parent);
      enchant.Set(enchantConfig);

      return enchant;
    }
  }
}