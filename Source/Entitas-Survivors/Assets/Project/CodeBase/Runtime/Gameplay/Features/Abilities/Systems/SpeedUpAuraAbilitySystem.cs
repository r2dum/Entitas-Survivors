using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Features.Armaments.Factory;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Abilities.Systems
{
  public class SpeedUpAuraAbilitySystem : IExecuteSystem
  {
    private readonly IArmamentFactory _armamentFactory;

    private readonly IGroup<GameEntity> _abilities;

    private readonly List<GameEntity> _buffer = new(64);

    public SpeedUpAuraAbilitySystem(GameContext gameContext, IArmamentFactory armamentFactory)
    {
      _armamentFactory = armamentFactory;

      _abilities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.SpeedUpAuraAbility,
          GameMatcher.ProducerId)
        .NoneOf(GameMatcher.Active));
    }

    public void Execute()
    {
      foreach (GameEntity ability in _abilities.GetEntities(_buffer))
      {
        _armamentFactory.CreateSpeedUpAura(AbilityId.SpeedUpAura, ability.ProducerId, 1);
        ability.isActive = true;
      }
    }
  }
}