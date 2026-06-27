using CodeBase.Runtime.Gameplay.Features.Hero.Behaviours;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Hero
{
  [Game] public class Hero : IComponent { }
  [Game] public class HeroAnimatorComponent : IComponent { public HeroAnimator Value; }
}