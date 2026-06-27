using CodeBase.Runtime.Infrastructure.EntityView.Registrars;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Core.Visuals.StatusVisuals
{
  public class StatusVisualsRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private StatusVisuals _statusVisuals;

    public override void RegisterComponents()
    {
      Entity.AddStatusVisuals(_statusVisuals);
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasStatusVisuals)
        Entity.RemoveStatusVisuals();
    }
  }
}