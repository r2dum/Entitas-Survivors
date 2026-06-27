using System;
using System.Collections.Generic;

namespace CodeBase.Runtime.Gameplay.Features.Statuses.Indexing
{
  public class StatusKeyEqualityComparer : IEqualityComparer<StatusKey>
  {
    public bool Equals(StatusKey x, StatusKey y) =>
      x.TargetId == y.TargetId && x.TypeId == y.TypeId;

    public int GetHashCode(StatusKey obj) =>
      HashCode.Combine(obj.TargetId, (int)obj.TypeId);
  }
}