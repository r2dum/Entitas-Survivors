using CodeBase.Runtime.Gameplay.Features.Enchants.Behaviours;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Enchants.UIFactory
{
  public interface IEnchantUIFactory
  {
    UniTask<Enchant> CreateEnchant(EnchantTypeId typeId, RectTransform parent);
  }
}