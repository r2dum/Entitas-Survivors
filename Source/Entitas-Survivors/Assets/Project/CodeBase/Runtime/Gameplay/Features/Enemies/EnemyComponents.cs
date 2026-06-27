using CodeBase.Runtime.Gameplay.Features.Enemies.Behaviours;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Enemies
{
  [Game] public class Enemy : IComponent { }
  [Game] public class EnemyAnimatorComponent : IComponent { public EnemyAnimator Value; }
  [Game] public class SpawnTimer : IComponent { public float Value; }
  [Game] public class EnemyTypeIdComponent : IComponent { public EnemyTypeId Value; }
}