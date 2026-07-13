using CodeBase.Runtime.Infrastructure.EntityView.Registrars;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Core.Visuals.Appearance
{
  public class AppearanceVisualsRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private AppearanceVisuals _appearanceVisuals;

    public override void RegisterComponents() =>
      Entity.AddAppearanceVisuals(_appearanceVisuals);

    public override void UnregisterComponents()
    {
      if (Entity.hasAppearanceVisuals)
        Entity.RemoveAppearanceVisuals();
    }
  }
}