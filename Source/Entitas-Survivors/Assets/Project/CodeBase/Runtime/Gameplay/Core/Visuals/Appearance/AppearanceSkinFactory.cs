using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Core.Visuals.Appearance
{
  public class AppearanceSkinFactory : IAppearanceSkinFactory
  {
    private readonly IInstantiator _instantiator;

    public AppearanceSkinFactory(IInstantiator instantiator) =>
      _instantiator = instantiator;

    public AppearanceSkin Create(AppearanceSkin prefab, Transform parent) =>
      _instantiator.InstantiatePrefabForComponent<AppearanceSkin>(prefab, parent);
  }
}