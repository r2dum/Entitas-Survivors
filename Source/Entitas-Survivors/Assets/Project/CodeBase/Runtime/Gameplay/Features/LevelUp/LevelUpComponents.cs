using CodeBase.Runtime.Gameplay.Features.LevelUp.Behaviours;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.LevelUp
{
  [Game] public class ExperienceMeterComponent : IComponent { public ExperienceMeter Value; }
  [Game] public class LevelUp : IComponent { }
}