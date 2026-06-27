using CodeBase.Runtime.Infrastructure.EntityView.Registrars;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Core.Visuals.Enchants
{
  public class EnchantVisualsRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private EnchantVisuals _enchantVisuals;

    public override void RegisterComponents()
    {
      Entity.AddEnchantVisuals(_enchantVisuals);
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasEnchantVisuals)
        Entity.RemoveEnchantVisuals();
    }
  }
}