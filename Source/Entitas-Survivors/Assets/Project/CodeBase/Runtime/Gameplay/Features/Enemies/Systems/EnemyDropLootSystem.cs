using CodeBase.Runtime.Gameplay.Features.Loot;
using CodeBase.Runtime.Gameplay.Features.Loot.Factory;
using Entitas;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Systems
{
  public class EnemyDropLootSystem : IExecuteSystem
  {
    private readonly ILootFactory _lootFactory;

    private readonly IGroup<GameEntity> _enemies;

    public EnemyDropLootSystem(GameContext gameContext, ILootFactory lootFactory)
    {
      _lootFactory = lootFactory;

      _enemies = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Enemy,
          GameMatcher.WorldPosition,
          GameMatcher.Dead,
          GameMatcher.ProcessingDeath));
    }
    public void Execute()
    {
      foreach (GameEntity enemy in _enemies)
      {
        if (Random.Range(0f, 1f) <= 0.15f)
          _lootFactory.CreateLootItem(LootTypeId.HealingItem, enemy.WorldPosition);
        else if (Random.Range(0f, 1f) <= 0.15f)
          _lootFactory.CreateLootItem(LootTypeId.PoisonEnchantItem, enemy.WorldPosition);
        else if (Random.Range(0f, 1f) <= 0.15f)
          _lootFactory.CreateLootItem(LootTypeId.ExplosionEnchantItem, enemy.WorldPosition);
        else if (Random.Range(0f, 1f) <= 0.15f)
          _lootFactory.CreateLootItem(LootTypeId.SheepHexEnchantItem, enemy.WorldPosition);
        else
          _lootFactory.CreateLootItem(LootTypeId.ExperienceGem, enemy.WorldPosition);
      }
    }
  }
}