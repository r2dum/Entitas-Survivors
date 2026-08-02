using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Runtime.Gameplay.Features.Enchants.Behaviours
{
  public class Enchant : MonoBehaviour
  {
    [SerializeField] private EnchantTypeId _typeId;
    [SerializeField] private Image _icon;

    public EnchantTypeId TypeId => _typeId;

    public void Set(EnchantConfig enchantConfig)
    {
      _typeId = enchantConfig.TypeId;
      _icon.sprite = enchantConfig.Icon;
    }
  }
}