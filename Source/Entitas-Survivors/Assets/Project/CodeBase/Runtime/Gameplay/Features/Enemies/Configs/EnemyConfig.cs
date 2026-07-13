using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Configs
{
  [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "Configs/Enemy/" + nameof(EnemyConfig))]
  public class EnemyConfig : ScriptableObject
  {
    public EnemyTypeId TypeId;
    [Range(0, 100)] public float SpawnWeight = 50;

    public float MaxHp;
    public float Speed;
    public float Damage;

  }
}