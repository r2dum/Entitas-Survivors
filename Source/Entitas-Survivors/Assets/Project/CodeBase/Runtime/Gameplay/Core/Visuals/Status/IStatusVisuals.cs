namespace CodeBase.Runtime.Gameplay.Core.Visuals.Status
{
  public interface IStatusVisuals
  {
    void ApplyFreeze();
    void UnapplyFreeze();
    void ApplyPoison();
    void UnapplyPoison();
  }
}