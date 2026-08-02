using UnityEngine;

namespace CodeBase.Runtime.Common.Randoms
{
  public class UnityRandomService : IRandomService
  {
    public float Range(float inclusiveMin, float inclusiveMax) =>
      Random.Range(inclusiveMin, inclusiveMax);

    public int Range(int inclusiveMin, int exclusiveMax) =>
      Random.Range(inclusiveMin, exclusiveMax);
  }
}