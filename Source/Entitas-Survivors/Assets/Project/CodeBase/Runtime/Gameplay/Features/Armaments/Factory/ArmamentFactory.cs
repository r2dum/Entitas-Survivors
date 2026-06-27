using System.Collections.Generic;
using CodeBase.Runtime.Common;
using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Gameplay.Features.Abilities;
using CodeBase.Runtime.Gameplay.Features.Abilities.Configs;
using CodeBase.Runtime.Gameplay.Features.Enchants;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
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

      return CreateProjectileEntity(at, abilityLevel, projectileSetup)
        .AddParentAbility(AbilityId.VegetableBolt)
        .With(x => x.isRotationAlignedAlongDirection = true);
    }

    public GameEntity CreateEnergyOrb(int level, Vector3 at)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.EnergyOrb, level);
      ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

      return CreateProjectileEntity(at, abilityLevel, projectileSetup)
        .AddParentAbility(AbilityId.EnergyOrb);
    }

    public GameEntity CreateOrbitingMushroom(int level, Vector3 at, float phase)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, level);
      ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

      return CreateProjectileEntity(at, abilityLevel, projectileSetup)
        .AddParentAbility(AbilityId.OrbitingMushroom)
        .AddOrbitPhase(phase)
        .AddOrbitRadius(projectileSetup.OrbitRadius);
    }

    public GameEntity CreateBouncingHummer(int level, Vector3 at)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.BouncingHummer, level);
      ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

      return CreateProjectileEntity(at, abilityLevel, projectileSetup)
        .AddParentAbility(AbilityId.BouncingHummer)
        .With(x => x.isRotationAlignedAlongDirection = true);
    }

    public GameEntity CreateEffectAura(AbilityId parentAbilityId, int producerId, int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.GarlicAura, level);
      AuraSetup auraSetup = abilityLevel.AuraSetup;

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

    private GameEntity CreateProjectileEntity(Vector3 at, AbilityLevel abilityLevel, ProjectileSetup setup) =>
      CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .AddViewPrefab(abilityLevel.ViewPrefab)
        .AddWorldPosition(at)
        .AddSpeed(setup.Speed)
        .AddRadius(setup.ContactRadius)
        .AddTargetBuffer(new List<int>(TargetBufferSize))
        .AddProcessedTargets(new List<int>(TargetBufferSize))
        .AddLayerMask(CollisionLayer.Enemy.AsMask())
        .AddSelfDestructTimer(setup.Lifetime)
        .With(x => x.AddTargetLimit(setup.Pierce), when: setup.Pierce > 0)
        .With(x => x.AddEffectSetups(abilityLevel.EffectSetups), when: abilityLevel.EffectSetups.IsNullOrEmpty() == false)
        .With(x => x.AddStatusSetups(abilityLevel.StatusSetups), when: abilityLevel.StatusSetups.IsNullOrEmpty() == false)
        .With(x => x.isArmament = true)
        .With(x => x.isMovementAvailable = true)
        .With(x => x.isReadyToCollectTargets = true)
        .With(x => x.isCollectingTargetsContinuously = true);
  }
}