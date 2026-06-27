using CodeBase.Runtime.Common.EntityIndices;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.CharacterStats.Systems
{
  public class StatChangeSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _statOwners;
    private readonly GameContext _gameContext;

    public StatChangeSystem(GameContext gameContext)
    {
      _gameContext = gameContext;

      _statOwners = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Id,
          GameMatcher.BaseStats,
          GameMatcher.StatModifiers));
    }

    public void Execute()
    {
      foreach (GameEntity statOwner in _statOwners)
      foreach (Stats stat in statOwner.BaseStats.Keys)
      {
        statOwner.StatModifiers[stat] = 0;

        foreach (GameEntity statChange in _gameContext.TargetStatChanges(stat, statOwner.Id))
          statOwner.StatModifiers[stat] += statChange.EffectValue;
      }
    }
  }
}