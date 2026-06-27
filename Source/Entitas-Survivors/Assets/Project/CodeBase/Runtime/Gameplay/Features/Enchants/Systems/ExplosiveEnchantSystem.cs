using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Features.Armaments.Factory;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Enchants.Systems
{
  public class ExplosiveEnchantSystem : ReactiveSystem<GameEntity>
  {
    private readonly IArmamentFactory _armamentFactory;
    private readonly IGroup<GameEntity> _enchants;

    public ExplosiveEnchantSystem(GameContext gameContext, IArmamentFactory armamentFactory) : base(gameContext)
    {
      _armamentFactory = armamentFactory;

      _enchants = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.EnchantTypeId,
          GameMatcher.ProducerId,
          GameMatcher.ExplosiveEnchant));
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher
        .AllOf(
          GameMatcher.Armament,
          GameMatcher.Reached)
        .Added());

    protected override bool Filter(GameEntity entity) =>
      entity.isArmament && entity.hasWorldPosition;

    protected override void Execute(List<GameEntity> armaments)
    {
      foreach (GameEntity enchant in _enchants)
      foreach (GameEntity armament in armaments)
        _armamentFactory.CreateExplosion(enchant.ProducerId, armament.WorldPosition);
    }
  }
}