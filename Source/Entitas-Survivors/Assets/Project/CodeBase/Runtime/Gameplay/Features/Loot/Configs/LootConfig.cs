using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Features.Effects;
using CodeBase.Runtime.Gameplay.Features.Statuses;
using CodeBase.Runtime.Infrastructure.EntityView;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Loot.Configs
{
  [CreateAssetMenu(fileName = nameof(LootConfig), menuName = "Configs/Loot/" + nameof(LootConfig))]
  public class LootConfig : ScriptableObject
  {
    public LootTypeId TypeId;
    public EntityBehaviour ViewPrefab;

    public float Experience;
    public List<EffectSetup> EffectSetups;
    public List<StatusSetup> StatusSetups;
  }
}