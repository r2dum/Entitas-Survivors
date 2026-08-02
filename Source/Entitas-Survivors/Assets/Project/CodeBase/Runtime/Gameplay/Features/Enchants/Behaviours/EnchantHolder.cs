using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Features.Enchants.UIFactory;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Features.Enchants.Behaviours
{
  public class EnchantHolder : MonoBehaviour
  {
    [SerializeField] private RectTransform _enchantLayout;

    private readonly List<Enchant> _enchants = new();

    private IEnchantUIFactory _enchantUIFactory;

    [Inject]
    private void Construct(IEnchantUIFactory enchantUIFactory) =>
      _enchantUIFactory = enchantUIFactory;

    public async void AddEnchant(EnchantTypeId typeId)
    {
      if (EnchantIsAlreadyHeld(typeId))
        return;

      Enchant enchant = await _enchantUIFactory.CreateEnchant(typeId, _enchantLayout);
      _enchants.Add(enchant);
    }

    public void RemoveEnchant(EnchantTypeId typeId)
    {
      Enchant enchant = _enchants.Find(x => x.TypeId == typeId);
      if (enchant == null)
        return;

      _enchants.Remove(enchant);
      Destroy(enchant.gameObject);
    }

    private bool EnchantIsAlreadyHeld(EnchantTypeId typeId) =>
      _enchants.Find(x => x.TypeId == typeId) != null;
  }
}