using System;
using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Features.Effects;
using CodeBase.Runtime.Gameplay.Features.Statuses;
using CodeBase.Runtime.Infrastructure.EntityView;

namespace CodeBase.Runtime.Gameplay.Features.Abilities.Configs
{
  [Serializable]
  public class ScatteringSetup
  {
    public EntityBehaviour ViewPrefab;
    public ProjectileSetup ProjectileSetup;

    public List<EffectSetup> EffectSetups;
    public List<StatusSetup> StatusSetups;
  }
}