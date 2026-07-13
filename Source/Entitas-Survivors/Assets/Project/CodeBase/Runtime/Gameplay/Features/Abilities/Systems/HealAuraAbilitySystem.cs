using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Features.Armaments.Factory;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Abilities.Systems
{
  public class HealAuraAbilitySystem : IExecuteSystem
  {
    private readonly IArmamentFactory _armamentFactory;

    private readonly IGroup<GameEntity> _abilities;
    private readonly IGroup<GameEntity> _producers;

    private readonly List<GameEntity> _buffer = new(64);

    public HealAuraAbilitySystem(GameContext gameContext, IArmamentFactory armamentFactory)
    {
      _armamentFactory = armamentFactory;

      _abilities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.HealAuraAbility,
          GameMatcher.ProducerId)
        .NoneOf(GameMatcher.Active));

      _producers = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Id,
          GameMatcher.Enemy));
    }

    public void Execute()
    {
      foreach (GameEntity ability in _abilities.GetEntities(_buffer))
      foreach (GameEntity producer in _producers)
      {
        if (ability.ProducerId == producer.Id)
        {
          _armamentFactory.CreateHealAura(AbilityId.HealAura, producer.Id, 1);
          ability.isActive = true;
        }
      }
    }
  }
}