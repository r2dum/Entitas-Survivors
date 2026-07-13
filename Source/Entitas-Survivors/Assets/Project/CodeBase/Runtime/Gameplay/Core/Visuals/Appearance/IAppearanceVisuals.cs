using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Core.Visuals.Appearance
{
  public interface IAppearanceVisuals
  {
    AppearanceSkin CurrentSkin { get; }
    SpriteRenderer Renderer { get; }
    Animator Animator { get; }

    void ApplySkin(AppearanceSkin appearanceSkin);
    void ClearSkin();
  }
}