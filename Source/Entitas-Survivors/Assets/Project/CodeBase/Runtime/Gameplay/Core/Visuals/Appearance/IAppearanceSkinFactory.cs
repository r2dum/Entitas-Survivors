using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Core.Visuals.Appearance
{
  public interface IAppearanceSkinFactory
  {
    AppearanceSkin Create(AppearanceSkin prefab, Transform parent);
  }
}