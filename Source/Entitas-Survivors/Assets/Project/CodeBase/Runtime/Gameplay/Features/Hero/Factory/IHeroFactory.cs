using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Hero.Factory
{
  public interface IHeroFactory
  {
    GameEntity CreateHero(Vector3 at);
  }
}