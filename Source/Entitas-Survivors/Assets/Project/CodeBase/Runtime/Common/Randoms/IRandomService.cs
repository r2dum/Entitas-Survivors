namespace CodeBase.Runtime.Common.Randoms
{
  public interface IRandomService
  {
    float Range(float inclusiveMin, float inclusiveMax);
    int Range(int inclusiveMin, int exclusiveMax);
  }
}