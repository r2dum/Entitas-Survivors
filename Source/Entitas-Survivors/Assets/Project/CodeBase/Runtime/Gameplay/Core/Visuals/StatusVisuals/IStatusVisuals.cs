namespace CodeBase.Runtime.Gameplay.Core.Visuals.StatusVisuals
{
  public interface IStatusVisuals
  {
    void ApplyFreeze();
    void UnapplyFreeze();
    void ApplyPoison();
    void UnapplyPoison();
  }
}