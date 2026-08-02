using CodeBase.Runtime.Infrastructure.AssetManagement;
using CodeBase.Runtime.Services.StaticData;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.UI.Windows.Factory
{
  public class WindowFactory : IWindowFactory
  {
    private readonly IStaticDataService _staticDataService;
    private readonly IAssetProvider _assetProvider;
    private readonly IInstantiator _instantiator;

    private RectTransform _uiRoot;

    public WindowFactory(IStaticDataService staticDataService, IAssetProvider assetProvider,
      IInstantiator instantiator)
    {
      _staticDataService = staticDataService;
      _assetProvider = assetProvider;
      _instantiator = instantiator;
    }

    public void SetUIRoot(RectTransform uiRoot) =>
      _uiRoot = uiRoot;

    public async UniTask<WindowBase> CreateWindow(WindowTypeId windowTypeId)
    {
      GameObject prefab = await _assetProvider.Load<GameObject>(_staticDataService.GetWindowReference(windowTypeId));
      return _instantiator.InstantiatePrefabForComponent<WindowBase>(prefab, _uiRoot);
    }
  }
}