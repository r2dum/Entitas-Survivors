using CodeBase.Runtime.Gameplay.Core.Visuals.Appearance;
using CodeBase.Runtime.Gameplay.Core.Visuals.Status;

namespace CodeBase.Runtime.Gameplay.Features.Statuses
{
  public static class AppearanceStatusVisualsExtensions
  {
    public static void UpdateStatusVisuals(this GameEntity target, AppearanceSkin currentSkin)
    {
      IStatusVisuals statusVisuals = currentSkin.StatusVisuals;

      if (statusVisuals != null)
        target.ReplaceStatusVisuals(statusVisuals);
      else if (target.hasStatusVisuals)
        target.RemoveStatusVisuals();
    }
  }
}