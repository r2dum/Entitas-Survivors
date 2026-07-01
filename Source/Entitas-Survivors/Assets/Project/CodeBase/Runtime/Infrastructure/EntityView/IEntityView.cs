using UnityEngine;

namespace CodeBase.Runtime.Infrastructure.EntityView
{
  public interface IEntityView
  {
    GameObject gameObject { get; }
    GameEntity Entity { get; }
    void SetEntity(GameEntity entity);
    void ReleaseColliders();
    void ReleaseEntity();
  }
}