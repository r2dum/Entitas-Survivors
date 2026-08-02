using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Levels.Providers
{
  public interface ILevelDataProvider
  {
    Vector3 StartPoint { get; }
    void SetStartPoint(Vector3 startPoint);
  }
}