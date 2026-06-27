using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Cooldowns
{
  [Game] public class Cooldown : IComponent { public float Value; }
  [Game] public class CooldownLeft : IComponent { public float Value; }
  [Game] public class CooldownUp : IComponent { }
}