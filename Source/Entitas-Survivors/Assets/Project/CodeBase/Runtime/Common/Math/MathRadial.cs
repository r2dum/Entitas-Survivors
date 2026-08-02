using System;
using UnityEngine;

namespace CodeBase.Runtime.Common.Math
{
  public static class MathRadial
  {
    public static float[] GetPhases(int count)
    {
      if (count <= 0)
        return Array.Empty<float>();

      float[] phases = new float[count];
      float angleBetween = 2 * Mathf.PI / count;

      for (int i = 0; i < count; i++)
        phases[i] = i * angleBetween;

      return phases;
    }

    public static Vector2[] GetRadialDirections(int count)
    {
      if (count <= 0)
        return Array.Empty<Vector2>();

      Vector2[] directions = new Vector2[count];
      float[] phases = GetPhases(count);

      for (int i = 0; i < count; i++)
      {
        float angle = phases[i];
        directions[i] = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
      }

      return directions;
    }
  }
}