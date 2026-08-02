using CodeBase.Runtime.Gameplay.Features.Enchants.Behaviours;
using CodeBase.Runtime.Infrastructure.EntityView.Registrars;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Enchants.Registrars
{
  public class EnchantHolderRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private EnchantHolder _enchantHolder;

    public override void RegisterComponents() =>
      Entity.AddEnchantHolder(_enchantHolder);

    public override void UnregisterComponents()
    {
      if (Entity.hasEnchantHolder)
        Entity.RemoveEnchantHolder();
    }
  }
}