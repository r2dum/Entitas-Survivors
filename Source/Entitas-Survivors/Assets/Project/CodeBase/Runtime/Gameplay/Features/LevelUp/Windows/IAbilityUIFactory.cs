using CodeBase.Runtime.Gameplay.Features.LevelUp.Behaviours;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.LevelUp.Windows
{
  public interface IAbilityUIFactory
  {
    UniTask<AbilityCard> CreateAbilityCard(RectTransform parent);
  }
}