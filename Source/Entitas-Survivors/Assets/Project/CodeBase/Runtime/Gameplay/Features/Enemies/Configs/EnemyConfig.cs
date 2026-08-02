using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Configs
{
  [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "Configs/Enemy/" + nameof(EnemyConfig))]
  public class EnemyConfig : ScriptableObject
  {
    public EnemyTypeId TypeId;
    public AssetReference ViewAddress;
    
    [Range(0, 100)] public float SpawnWeight = 50;
    public float UnlockTime;

    public float MaxHp;
    public float Speed;
    public float Damage;

    public List<EnemyAbilitySetup> AbilitySetups;
  }
}