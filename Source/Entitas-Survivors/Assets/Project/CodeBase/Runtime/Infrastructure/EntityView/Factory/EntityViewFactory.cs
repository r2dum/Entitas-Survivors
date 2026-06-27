using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Infrastructure.EntityView.Factory
{
  public class EntityViewFactory : IEntityViewFactory
  {
    private readonly IInstantiator _instantiator;

    private readonly Vector3 _farAwayPosition = new(-999f, 999f, 0f);

    public EntityViewFactory(IInstantiator instantiator) =>
      _instantiator = instantiator;

    public void CreateViewForEntity(GameEntity entity)
    {
      EntityBehaviour view = _instantiator
        .InstantiatePrefabForComponent<EntityBehaviour>(entity.ViewPrefab, _farAwayPosition, Quaternion.identity, null);

      view.SetEntity(entity);
    }
  }
}