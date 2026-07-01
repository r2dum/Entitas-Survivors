using CodeBase.Runtime.Common.Destruct;
using CodeBase.Runtime.Gameplay.Features.Abilities;
using CodeBase.Runtime.Gameplay.Features.Armaments;
using CodeBase.Runtime.Gameplay.Features.CharacterStats;
using CodeBase.Runtime.Gameplay.Features.EffectApplication;
using CodeBase.Runtime.Gameplay.Features.Effects;
using CodeBase.Runtime.Gameplay.Features.Enchants;
using CodeBase.Runtime.Gameplay.Features.Enemies;
using CodeBase.Runtime.Gameplay.Features.Hero;
using CodeBase.Runtime.Gameplay.Features.Lifetime;
using CodeBase.Runtime.Gameplay.Features.Movement;
using CodeBase.Runtime.Gameplay.Features.Statuses;
using CodeBase.Runtime.Gameplay.Features.TargetCollection;
using CodeBase.Runtime.Gameplay.Input;
using CodeBase.Runtime.Infrastructure.EntityView;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay
{
  public sealed class BattleFeature : Feature
  {
    public BattleFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<InputFeature>());
      Add(systemFactory.Create<BindViewFeature>());

      Add(systemFactory.Create<HeroFeature>());
      Add(systemFactory.Create<EnemyFeature>());
      Add(systemFactory.Create<DeathFeature>());

      Add(systemFactory.Create<MovementFeature>());
      Add(systemFactory.Create<AbilityFeature>());

      Add(systemFactory.Create<CollectTargetsFeature>());

      Add(systemFactory.Create<EffectApplicationFeature>());
      Add(systemFactory.Create<EnchantFeature>());
      Add(systemFactory.Create<EffectFeature>());
      Add(systemFactory.Create<StatusFeature>());
      Add(systemFactory.Create<StatsFeature>());

      Add(systemFactory.Create<ArmamentFeature>());

      Add(systemFactory.Create<ProcessDestructedFeature>());
    }
  }
}