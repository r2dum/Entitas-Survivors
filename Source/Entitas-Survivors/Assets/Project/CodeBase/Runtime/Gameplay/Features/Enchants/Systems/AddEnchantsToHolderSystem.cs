using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Enchants.Systems
{
  public class AddEnchantsToHolderSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _enchantHolders;
    private readonly IGroup<GameEntity> _enchants;

    public AddEnchantsToHolderSystem(GameContext gameContext)
    {
      _enchantHolders = gameContext.GetGroup(GameMatcher.EnchantHolder);

      _enchants = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.EnchantTypeId,
          GameMatcher.TimeLeft));
    }

    public void Execute()
    {
      foreach (GameEntity enchantHolder in _enchantHolders)
      foreach (GameEntity enchant in _enchants)
        enchantHolder.EnchantHolder.AddEnchant(enchant.EnchantTypeId);
    }
  }
}