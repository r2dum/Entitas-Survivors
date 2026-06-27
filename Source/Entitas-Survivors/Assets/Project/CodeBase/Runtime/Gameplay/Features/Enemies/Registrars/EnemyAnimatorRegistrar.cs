using CodeBase.Runtime.Gameplay.Features.Enemies.Behaviours;
using CodeBase.Runtime.Infrastructure.EntityView.Registrars;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Registrars
{
  public class EnemyAnimatorRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private EnemyAnimator _enemyAnimator;

    public override void RegisterComponents()
    {
      Entity
        .AddEnemyAnimator(_enemyAnimator)
        .AddDamageTakenAnimator(_enemyAnimator);
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasEnemyAnimator)
        Entity.RemoveEnemyAnimator();

      if (Entity.hasDamageTakenAnimator)
        Entity.RemoveDamageTakenAnimator();
    }
  }
}