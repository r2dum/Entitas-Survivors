using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Levels
{
  public class LevelDataProvider : ILevelDataProvider
  {
    public Vector3 StartPoint { get; private set; }

    public void SetStartPoint(Vector3 startPoint) =>
      StartPoint = startPoint;
  }
}