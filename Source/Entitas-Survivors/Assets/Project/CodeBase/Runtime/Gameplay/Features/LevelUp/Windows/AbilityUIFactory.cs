using CodeBase.Runtime.Common;
using CodeBase.Runtime.Gameplay.Features.LevelUp.Behaviours;
using CodeBase.Runtime.Infrastructure.AssetManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Features.LevelUp.Windows
{
  public class AbilityUIFactory : IAbilityUIFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly IInstantiator _instantiator;

    public AbilityUIFactory(IAssetProvider assetProvider, IInstantiator instantiator)
    {
      _assetProvider = assetProvider;
      _instantiator = instantiator;
    }

    public async UniTask<AbilityCard> CreateAbilityCard(RectTransform parent)
    {
      GameObject prefab = await _assetProvider.Load<GameObject>(AssetAddress.AbilityCardUI);
      return _instantiator.InstantiatePrefabForComponent<AbilityCard>(prefab, parent);
    }
  }
}