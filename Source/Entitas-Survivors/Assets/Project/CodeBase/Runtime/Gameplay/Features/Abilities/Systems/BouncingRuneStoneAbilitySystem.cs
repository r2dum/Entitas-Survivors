using System.Collections.Generic;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Gameplay.Core;
using CodeBase.Runtime.Gameplay.Features.Abilities.Configs;
using CodeBase.Runtime.Gameplay.Features.Abilities.Upgrade;
using CodeBase.Runtime.Gameplay.Features.Armaments.Factory;
using CodeBase.Runtime.Gameplay.Features.Cooldowns;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Abilities.Systems
{
  public class BouncingRuneStoneAbilitySystem : IExecuteSystem
  {
    private readonly IGameplayStaticDataService _staticDataService;
    private readonly IArmamentFactory _armamentFactory;
    private readonly IAbilityUpgradeService _abilityUpgradeService;

    private readonly IGroup<GameEntity> _abilities;
    private readonly IGroup<GameEntity> _heroes;
    private readonly IGroup<GameEntity> _enemies;

    private readonly List<GameEntity> _buffer = new(1);

    public BouncingRuneStoneAbilitySystem(GameContext gameContext, IGameplayStaticDataService staticDataService,
      IArmamentFactory armamentFactory, IAbilityUpgradeService abilityUpgradeService)
    {
      _staticDataService = staticDataService;
      _armamentFactory = armamentFactory;
      _abilityUpgradeService = abilityUpgradeService;

      _abilities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.BouncingRuneStoneAbility,
          GameMatcher.CooldownUp));

      _heroes = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.WorldPosition));

      _enemies = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Enemy,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity ability in _abilities.GetEntities(_buffer))
      foreach (GameEntity hero in _heroes)
      {
        if (_enemies.count <= 0)
          continue;

        GameEntity nearestEnemy = _enemies.GetNearest(hero.WorldPosition);

        if (nearestEnemy == null)
          continue;

        int level = _abilityUpgradeService.GetAbilityLevel(AbilityId.BouncingRuneStone);

        AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.BouncingRuneStone, level);

        _armamentFactory
          .CreateBouncingRuneStone(level, hero.WorldPosition)
          .AddProducerId(hero.Id)
          .ReplaceDirection((nearestEnemy.WorldPosition - hero.WorldPosition).normalized)
          .With(x => x.isMoving = true);

        ability.PutOnCooldown(abilityLevel.Cooldown);
      }
    }
  }
}