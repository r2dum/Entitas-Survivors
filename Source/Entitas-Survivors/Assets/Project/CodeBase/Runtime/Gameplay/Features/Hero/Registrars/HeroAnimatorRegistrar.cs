using CodeBase.Runtime.Gameplay.Features.Hero.Behaviours;
using CodeBase.Runtime.Infrastructure.EntityView.Registrars;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Hero.Registrars
{
  public class HeroAnimatorRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private HeroAnimator _heroAnimator;

    public override void RegisterComponents()
    {
      Entity
        .AddHeroAnimator(_heroAnimator)
        .AddDamageTakenAnimator(_heroAnimator);
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasHeroAnimator)
        Entity.RemoveHeroAnimator();

      if (Entity.hasDamageTakenAnimator)
        Entity.RemoveDamageTakenAnimator();
    }
  }
}