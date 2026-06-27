using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Core.Collisions;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Core.Physics
{
  public class PhysicsService : IPhysicsService
  {
    private static readonly List<RaycastHit2D> Hits = new(128);
    private static readonly List<Collider2D> OverlapHits = new(128);

    private readonly ICollisionRegistry _collisionRegistry;

    public PhysicsService(ICollisionRegistry collisionRegistry) =>
      _collisionRegistry = collisionRegistry;

    public IEnumerable<GameEntity> RaycastAll(Vector2 worldPosition, Vector2 direction, int layerMask)
    {
      ContactFilter2D contactFilter = CreateContactFilter(layerMask);
      int hitCount = Physics2D.Raycast(worldPosition, direction, contactFilter, Hits);

      for (int i = 0; i < hitCount; i++)
      {
        RaycastHit2D hit = Hits[i];
        if (hit.collider == null)
          continue;

        GameEntity entity = _collisionRegistry.Get<GameEntity>(hit.collider.GetInstanceID());
        if (entity == null)
          continue;

        yield return entity;
      }
    }

    public GameEntity Raycast(Vector2 worldPosition, Vector2 direction, int layerMask)
    {
      ContactFilter2D contactFilter = CreateContactFilter(layerMask);
      int hitCount = Physics2D.Raycast(worldPosition, direction, contactFilter, Hits);

      for (int i = 0; i < hitCount; i++)
      {
        RaycastHit2D hit = Hits[i];
        if (hit.collider == null)
          continue;

        GameEntity entity = _collisionRegistry.Get<GameEntity>(hit.collider.GetInstanceID());
        if (entity == null)
          continue;

        return entity;
      }

      return null;
    }

    public GameEntity LineCast(Vector2 start, Vector2 end, int layerMask)
    {
      ContactFilter2D contactFilter = CreateContactFilter(layerMask);
      int hitCount = Physics2D.Linecast(start, end, contactFilter, Hits);

      for (int i = 0; i < hitCount; i++)
      {
        RaycastHit2D hit = Hits[i];
        if (hit.collider == null)
          continue;

        GameEntity entity = _collisionRegistry.Get<GameEntity>(hit.collider.GetInstanceID());
        if (entity == null)
          continue;

        return entity;
      }

      return null;
    }

    public IEnumerable<GameEntity> CircleCast(Vector3 worldPosition, float radius, int layerMask)
    {
      int hitCount = OverlapCircle(worldPosition, radius, OverlapHits, layerMask);

      DrawDebug(worldPosition, radius, 1f, Color.red);

      for (int i = 0; i < hitCount; i++)
      {
        GameEntity entity = _collisionRegistry.Get<GameEntity>(OverlapHits[i].GetInstanceID());
        if (entity == null)
          continue;

        yield return entity;
      }
    }

    public int CircleCast(Vector3 worldPosition, float radius, int layerMask, GameEntity[] hitBuffer)
    {
      int hitCount = OverlapCircle(worldPosition, radius, OverlapHits, layerMask);

      DrawDebug(worldPosition, radius, 1f, Color.green);

      for (int i = 0; i < hitCount; i++)
      {
        GameEntity entity = _collisionRegistry.Get<GameEntity>(OverlapHits[i].GetInstanceID());
        if (entity == null)
          continue;

        if (i < hitBuffer.Length)
          hitBuffer[i] = entity;
      }

      return hitCount;
    }

    public TEntity OverlapPoint<TEntity>(Vector2 worldPosition, int layerMask) where TEntity : class
    {
      ContactFilter2D contactFilter = CreateContactFilter(layerMask);
      int hitCount = Physics2D.OverlapPoint(worldPosition, contactFilter, OverlapHits);

      for (int i = 0; i < hitCount; i++)
      {
        Collider2D hit = OverlapHits[i];
        if (hit == null)
          continue;

        TEntity entity = _collisionRegistry.Get<TEntity>(hit.GetInstanceID());
        if (entity == null)
          continue;

        return entity;
      }

      return null;
    }

    public int OverlapCircle(Vector3 worldPosition, float radius, List<Collider2D> hits, int layerMask)
    {
      ContactFilter2D contactFilter = CreateContactFilter(layerMask);
      return Physics2D.OverlapCircle(worldPosition, radius, contactFilter, hits);
    }

    private ContactFilter2D CreateContactFilter(int layerMask)
    {
      ContactFilter2D filter = new();
      filter.SetLayerMask(layerMask);
      filter.useLayerMask = true;
      filter.useTriggers = true;
      return filter;
    }

    private static void DrawDebug(Vector2 worldPos, float radius, float seconds, Color color)
    {
      Debug.DrawRay(worldPos, radius * Vector3.up, color, seconds);
      Debug.DrawRay(worldPos, radius * Vector3.down, color, seconds);
      Debug.DrawRay(worldPos, radius * Vector3.left, color, seconds);
      Debug.DrawRay(worldPos, radius * Vector3.right, color, seconds);
    }
  }
}