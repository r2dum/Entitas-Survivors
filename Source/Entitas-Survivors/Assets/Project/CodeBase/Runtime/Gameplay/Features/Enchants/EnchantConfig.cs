using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Features.Effects;
using CodeBase.Runtime.Gameplay.Features.Statuses;
using CodeBase.Runtime.Infrastructure.EntityView;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Enchants
{
  [CreateAssetMenu(fileName = nameof(EnchantConfig), menuName = "Configs/Enchant/" + nameof(EnchantConfig))]
  public class EnchantConfig : ScriptableObject
  {
    public EnchantTypeId TypeId;
    public EntityBehaviour ViewPrefab;
    public float Radius;

    public List<EffectSetup> EffectSetups;
    public List<StatusSetup> StatusSetups;
  }
}