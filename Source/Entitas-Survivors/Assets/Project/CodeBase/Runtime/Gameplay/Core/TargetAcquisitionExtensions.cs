using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Core
{
  public static class TargetAcquisitionExtensions
  {
    public static GameEntity GetNearest(this IGroup<GameEntity> entities, Vector3 to)
    {
      if (entities.count == 0)
        return null;

      GameEntity nearestEntity = null;
      float minDistanceSqr = float.MaxValue;

      foreach (GameEntity entity in entities)
      {
        float distanceSqr = (entity.WorldPosition - to).sqrMagnitude;
        if (distanceSqr < minDistanceSqr)
        {
          minDistanceSqr = distanceSqr;
          nearestEntity = entity;
        }
      }

      return nearestEntity;
    }

    public static GameEntity GetNearestExcept(this IGroup<GameEntity> entities, Vector3 to, List<int> exceptedIds)
    {
      if (entities.count == 0)
        return null;

      GameEntity nearestEntity = null;
      float minDistanceSqr = float.MaxValue;

      foreach (GameEntity entity in entities)
      {
        if (exceptedIds.Contains(entity.Id))
          continue;

        float distanceSqr = (entity.WorldPosition - to).sqrMagnitude;
        if (distanceSqr < minDistanceSqr)
        {
          minDistanceSqr = distanceSqr;
          nearestEntity = entity;
        }
      }

      return nearestEntity;
    }
  }
}