using System;
using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Features.Effects;
using CodeBase.Runtime.Gameplay.Features.Statuses;
using CodeBase.Runtime.Infrastructure.EntityView;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Abilities.Configs
{
  [Serializable]
  public class AbilityLevel
  {
    public Sprite Icon;
    public string Description;
    public EntityBehaviour ViewPrefab;

    public float Cooldown;

    public List<EffectSetup> EffectSetups;
    public List<StatusSetup> StatusSetups;

    public ProjectileSetup ProjectileSetup;
    public AuraSetup AuraSetup;

    public ChildArmamentSetup ChildArmamentSetup;
  }
}