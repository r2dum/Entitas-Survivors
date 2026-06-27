using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Factory
{
  public interface IEnemyFactory
  {
    GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at);
  }
}