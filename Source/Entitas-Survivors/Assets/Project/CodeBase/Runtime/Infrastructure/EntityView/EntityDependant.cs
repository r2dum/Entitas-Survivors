using UnityEngine;

namespace CodeBase.Runtime.Infrastructure.EntityView
{
  public abstract class EntityDependant : MonoBehaviour
  {
    [SerializeField] private EntityBehaviour _entityView;

    public GameEntity Entity => _entityView != null ? _entityView.Entity : null;

    private void Awake()
    {
      if (_entityView == false)
        _entityView = GetComponent<EntityBehaviour>();
    }
  }
}