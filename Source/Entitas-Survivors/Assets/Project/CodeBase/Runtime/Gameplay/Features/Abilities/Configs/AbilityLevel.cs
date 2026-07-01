using System;
using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Features.Effects;
using CodeBase.Runtime.Gameplay.Features.Statuses;
using CodeBase.Runtime.Infrastructure.EntityView;

namespace CodeBase.Runtime.Gameplay.Features.Abilities.Configs
{
  [Serializable]
  public class AbilityLevel
  {
    public float Cooldown;

    public EntityBehaviour ViewPrefab;

    public List<EffectSetup> EffectSetups;
    public List<StatusSetup> StatusSetups;

    public ProjectileSetup ProjectileSetup;
    public AuraSetup AuraSetup;

    public ScatteringSetup ScatteringSetup;
  }
}