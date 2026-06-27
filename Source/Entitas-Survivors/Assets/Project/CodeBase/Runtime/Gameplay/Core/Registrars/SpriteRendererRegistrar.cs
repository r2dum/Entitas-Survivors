using CodeBase.Runtime.Infrastructure.EntityView.Registrars;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Core.Registrars
{
  public class SpriteRendererRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public override void RegisterComponents()
    {
      Entity.AddSpriteRenderer(_spriteRenderer);
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasSpriteRenderer)
        Entity.RemoveSpriteRenderer();
    }
  }
}