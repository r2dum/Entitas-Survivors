using System.Collections.Generic;
using CodeBase.Runtime.Common;
using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Gameplay.Features.Abilities;
using CodeBase.Runtime.Gameplay.Features.Abilities.Configs;
using CodeBase.Runtime.Gameplay.Features.Effects;
using CodeBase.Runtime.Gameplay.Features.Enchants;
using CodeBase.Runtime.Gameplay.Features.Statuses;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
using CodeBase.Runtime.Infrastructure.EntityView;
using CodeBase.Runtime.Infrastructure.Identifiers;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Armaments.Factory
{
  public class ArmamentFactory : IArmamentFactory
  {
    private const int TargetBufferSize = 16;

    private readonly IIdentifierService _identifierService;
    private readonly IGameplayStaticDataService _staticDataService;

    public ArmamentFactory(IIdentifierService identifierService, IGameplayStaticDataService staticDataService)
    {
      _identifierService = identifierService;
      _staticDataService = staticDataService;
    }

    public GameEntity CreateVegetableBolt(int level, Vector3 at)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.VegetableBolt, level);
      ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

      return CreateProjectileEntity(at, abilityLevel.ViewPrefab, projectileSetup,
          abilityLevel.EffectSetups, abilityLevel.StatusSetups)
        .AddParentAbility(AbilityId.VegetableBolt)
        .With(x => x.isRotationAlignedAlongDirection = true);
    }

    public GameEntity CreateRadialEnergyOrb(int level, Vector3 at)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.RadialEnergyOrb, level);
      ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

      return CreateProjectileEntity(at, abilityLevel.ViewPrefab, projectileSetup,
          abilityLevel.EffectSetups, abilityLevel.StatusSetups)
        .AddParentAbility(AbilityId.RadialEnergyOrb);
    }

    public GameEntity CreateOrbitingMushroom(int level, Vector3 at, float phase)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, level);
      ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

      return CreateProjectileEntity(at, abilityLevel.ViewPrefab, projectileSetup,
          abilityLevel.EffectSetups, abilityLevel.StatusSetups)
        .AddParentAbility(AbilityId.OrbitingMushroom)
        .AddOrbitPhase(phase)
        .AddOrbitRadius(projectileSetup.OrbitRadius);
    }

    public GameEntity CreateBouncingRuneStone(int level, Vector3 at)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.BouncingRuneStone, level);
      ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

      return CreateProjectileEntity(at, abilityLevel.ViewPrefab, projectileSetup,
          abilityLevel.EffectSetups, abilityLevel.StatusSetups)
        .AddParentAbility(AbilityId.BouncingRuneStone)
        .AddTargetBounceLimit(projectileSetup.Bounce)
        .With(x => x.isRotationAlignedAlongDirection = true);
    }

    public GameEntity CreateScatteringFireBall(int level, Vector3 at)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.ScatteringFireBall, level);
      ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

      return CreateProjectileEntity(at, abilityLevel.ViewPrefab, projectileSetup,
          abilityLevel.EffectSetups, abilityLevel.StatusSetups)
        .AddParentAbility(AbilityId.ScatteringFireBall)
        .With(x => x.isScattering = true)
        .With(x => x.isRotationAlignedAlongDirection = true);
    }

    public GameEntity CreateScatteringFireBallShard(int level, Vector3 at)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.ScatteringFireBall, level);
      ScatteringSetup scatteringSetup = abilityLevel.ScatteringSetup;

      return CreateProjectileEntity(at, scatteringSetup.ViewPrefab, scatteringSetup.ProjectileSetup,
          scatteringSetup.EffectSetups, scatteringSetup.StatusSetups)
        .AddParentAbility(AbilityId.ScatteringFireBall)
        .With(x => x.isRotationAlignedAlongDirection = true);
    }

    public GameEntity CreateGarlicAura(AbilityId parentAbilityId, int producerId, int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.GarlicAura, level);
      AuraSetup auraSetup = abilityLevel.AuraSetup;
      return CreateAuraEntity(parentAbilityId, producerId, abilityLevel, auraSetup);
    }

    public GameEntity CreateHealAura(AbilityId parentAbilityId, int producerId, int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.HealAura, level);
      AuraSetup auraSetup = abilityLevel.AuraSetup;
      return CreateAuraEntity(parentAbilityId, producerId, abilityLevel, auraSetup);
    }

    public GameEntity CreateSpeedUpAura(AbilityId parentAbilityId, int producerId, int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.SpeedUpAura, level);
      AuraSetup auraSetup = abilityLevel.AuraSetup;
      return CreateAuraEntity(parentAbilityId, producerId, abilityLevel, auraSetup);
    }

    public GameEntity CreateExplosion(int producerId, Vector3 at)
    {
      EnchantConfig enchantConfig = _staticDataService.GetEnchantConfig(EnchantTypeId.ExplosiveArmaments);

      return CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .AddProducerId(producerId)
        .AddViewPrefab(enchantConfig.ViewPrefab)
        .AddWorldPosition(at)
        .AddLayerMask(CollisionLayer.Enemy.AsMask())
        .AddRadius(enchantConfig.Radius)
        .AddSelfDestructTimer(1f)
        .AddTargetBuffer(new List<int>(TargetBufferSize))
        .With(x => x.AddEffectSetups(enchantConfig.EffectSetups), when: enchantConfig.EffectSetups.IsNullOrEmpty() == false)
        .With(x => x.AddStatusSetups(enchantConfig.StatusSetups), when: enchantConfig.StatusSetups.IsNullOrEmpty() == false)
        .With(x => x.isReadyToCollectTargets = true);
    }

    private GameEntity CreateProjectileEntity(Vector3 at, EntityBehaviour viewPrefab, ProjectileSetup projectileSetup,
      List<EffectSetup> effectSetups, List<StatusSetup> statusSetups)
    {
      return CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .AddViewPrefab(viewPrefab)
        .AddWorldPosition(at)
        .AddSpeed(projectileSetup.Speed)
        .AddRadius(projectileSetup.ContactRadius)
        .AddTargetBuffer(new List<int>(TargetBufferSize))
        .AddProcessedTargets(new List<int>(TargetBufferSize))
        .AddLayerMask(CollisionLayer.Enemy.AsMask())
        .AddSelfDestructTimer(projectileSetup.Lifetime)
        .With(x => x.AddTargetPierceLimit(projectileSetup.Pierce), when: projectileSetup.Pierce > 0)
        .With(x => x.AddEffectSetups(effectSetups), when: effectSetups.IsNullOrEmpty() == false)
        .With(x => x.AddStatusSetups(statusSetups), when: statusSetups.IsNullOrEmpty() == false)
        .With(x => x.isArmament = true)
        .With(x => x.isMovementAvailable = true)
        .With(x => x.isReadyToCollectTargets = true)
        .With(x => x.isCollectingTargetsContinuously = true);
    }

    private GameEntity CreateAuraEntity(AbilityId parentAbilityId, int producerId, AbilityLevel abilityLevel, AuraSetup auraSetup)
    {
      return CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .AddParentAbility(parentAbilityId)
        .AddProducerId(producerId)
        .AddViewPrefab(abilityLevel.ViewPrefab)
        .AddWorldPosition(Vector3.zero)
        .AddLayerMask(CollisionLayer.Enemy.AsMask())
        .AddRadius(auraSetup.Radius)
        .AddCollectTargetsInterval(auraSetup.Interval)
        .AddCollectTargetsTimer(0f)
        .AddTargetBuffer(new List<int>(TargetBufferSize))
        .With(x => x.AddEffectSetups(abilityLevel.EffectSetups), when: abilityLevel.EffectSetups.IsNullOrEmpty() == false)
        .With(x => x.AddStatusSetups(abilityLevel.StatusSetups), when: abilityLevel.StatusSetups.IsNullOrEmpty() == false)
        .With(x => x.isFollowingProducer = true);
    }
  }
}