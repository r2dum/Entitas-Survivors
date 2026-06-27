using CodeBase.Runtime.Infrastructure.EntityView;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Runtime.Infrastructure.AssetManagement
{
  public class EntityViewAssetLoader : IEntityViewAssetLoader
  {
    private readonly IAssetProvider _assetProvider;

    public EntityViewAssetLoader(IAssetProvider assetProvider) =>
      _assetProvider = assetProvider;

    public void Load(GameEntity entity, string address) =>
      LoadViewPrefabAsync(entity, address).Forget();

    private async UniTaskVoid LoadViewPrefabAsync(GameEntity entity, string address)
    {
      GameObject prefab = await _assetProvider.Load<GameObject>(address);

      if (entity == null)
        return;

      entity.isViewAddressLoading = false;
      EntityBehaviour viewPrefab = prefab.GetComponent<EntityBehaviour>();
      entity.AddViewPrefab(viewPrefab);
    }
  }
}