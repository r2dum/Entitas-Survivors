using System;
using System.Collections.Generic;

namespace CodeBase.Runtime.Gameplay.Features.CharacterStats.Indexing
{
  public class StatKeyEqualityComparer : IEqualityComparer<StatKey>
  {
    public bool Equals(StatKey x, StatKey y) =>
      x.TargetId == y.TargetId && x.Stat == y.Stat;

    public int GetHashCode(StatKey obj) =>
      HashCode.Combine(obj.TargetId, (int)obj.Stat);
  }
}