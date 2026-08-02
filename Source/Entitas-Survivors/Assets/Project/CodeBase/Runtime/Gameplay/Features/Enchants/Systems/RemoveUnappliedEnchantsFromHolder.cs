using System.Collections.Generic;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Enchants.Systems
{
  public class RemoveUnappliedEnchantsFromHolder : ReactiveSystem<GameEntity>
  {
    private readonly IGroup<GameEntity> _enchantHolders;

    public RemoveUnappliedEnchantsFromHolder(GameContext gameContext) : base(gameContext) =>
      _enchantHolders = gameContext.GetGroup(GameMatcher.EnchantHolder);

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher
        .AllOf(
          GameMatcher.EnchantTypeId,
          GameMatcher.Unapplied)
        .Added());

    protected override bool Filter(GameEntity entity) => true;

    protected override void Execute(List<GameEntity> entities)
    {
      foreach (GameEntity entity in entities)
      foreach (GameEntity enchantHolder in _enchantHolders)
        enchantHolder.EnchantHolder.RemoveEnchant(entity.EnchantTypeId);
    }
  }
}