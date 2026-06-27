using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Features.Statuses;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Enchants.Systems
{
  public class PoisonEnchantSystem : IExecuteSystem
  {
    private readonly IGameplayStaticDataService _staticDataService;

    private readonly IGroup<GameEntity> _enchants;
    private readonly IGroup<GameEntity> _armaments;

    private readonly List<GameEntity> _buffer = new(32);

    public PoisonEnchantSystem(GameContext gameContext, IGameplayStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;

      _enchants = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.EnchantTypeId,
          GameMatcher.ProducerId,
          GameMatcher.PoisonEnchant));

      _armaments = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament,
          GameMatcher.ProducerId)
        .NoneOf(GameMatcher.PoisonEnchant));
    }

    public void Execute()
    {
      foreach (GameEntity enchant in _enchants)
      foreach (GameEntity armament in _armaments.GetEntities(_buffer))
      {
        if (enchant.ProducerId == armament.ProducerId)
        {
          GetOrAddStatusSetups(armament).AddRange(_staticDataService.GetEnchantConfig(EnchantTypeId.PoisonArmaments).StatusSetups);
          armament.isPoisonEnchant = true;
        }
      }
    }

    private static List<StatusSetup> GetOrAddStatusSetups(GameEntity armament)
    {
      if (armament.hasStatusSetups == false)
        armament.AddStatusSetups(new List<StatusSetup>());

      return armament.StatusSetups;
    }
  }

}