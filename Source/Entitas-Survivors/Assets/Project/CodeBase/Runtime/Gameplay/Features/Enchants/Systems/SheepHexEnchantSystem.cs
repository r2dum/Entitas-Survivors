using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Features.Statuses;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Enchants.Systems
{
  public class SheepHexEnchantSystem : IExecuteSystem
  {
    private readonly IGameplayStaticDataService _staticDataService;

    private readonly IGroup<GameEntity> _enchants;
    private readonly IGroup<GameEntity> _armaments;

    private readonly List<GameEntity> _buffer = new(32);

    public SheepHexEnchantSystem(GameContext gameContext, IGameplayStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;

      _enchants = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.EnchantTypeId,
          GameMatcher.ProducerId,
          GameMatcher.SheepHexEnchant));

      _armaments = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament,
          GameMatcher.ProducerId)
        .NoneOf(GameMatcher.SheepHexEnchant));
    }

    public void Execute()
    {
      foreach (GameEntity enchant in _enchants)
      foreach (GameEntity armament in _armaments.GetEntities(_buffer))
      {
        if (enchant.ProducerId == armament.ProducerId)
        {
          GetOrAddStatusSetups(armament).AddRange(_staticDataService.GetEnchantConfig(EnchantTypeId.SheepHexArmaments).StatusSetups);
          armament.isSheepHexEnchant = true;
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