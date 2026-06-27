using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Features.CharacterStats;
using CodeBase.Runtime.Gameplay.Features.CharacterStats.Indexing;
using CodeBase.Runtime.Gameplay.Features.Effects;
using CodeBase.Runtime.Gameplay.Features.Statuses;
using CodeBase.Runtime.Gameplay.Features.Statuses.Indexing;
using Entitas;
using Zenject;

namespace CodeBase.Runtime.Common.EntityIndices
{
  public class GameEntityIndices : IInitializable
  {
    private readonly GameContext _gameContext;

    public const string StatusesOfType = "StatusesOfType";
    public const string StatChanges = "StatChanges";

    public GameEntityIndices(GameContext gameContext) =>
      _gameContext = gameContext;

    public void Initialize()
    {
      _gameContext.AddEntityIndex(new EntityIndex<GameEntity, StatusKey>(
        name: StatusesOfType,
        _gameContext.GetGroup(GameMatcher.AllOf(
          GameMatcher.StatusTypeId,
          GameMatcher.TargetId,
          GameMatcher.Status,
          GameMatcher.Duration,
          GameMatcher.TimeLeft)),
        getKey: GetTargetStatusKey,
        new StatusKeyEqualityComparer()));

      _gameContext.AddEntityIndex(new EntityIndex<GameEntity, StatKey>(
        name: StatChanges,
        _gameContext.GetGroup(GameMatcher.AllOf(
          GameMatcher.StatChange,
          GameMatcher.TargetId)),
        getKey: GetTargetStatKey,
        new StatKeyEqualityComparer()));
    }

    private StatKey GetTargetStatKey(GameEntity entity, IComponent component)
    {
      return new StatKey(
        (component as TargetId)?.Value ?? entity.TargetId,
        (component as StatChange)?.Value ?? entity.StatChange);
    }

    private StatusKey GetTargetStatusKey(GameEntity entity, IComponent component)
    {
      return new StatusKey(
        (component as TargetId)?.Value ?? entity.TargetId,
        (component as StatusTypeIdComponent)?.Value ?? entity.StatusTypeId);
    }
  }

  public static class ContextIndicesExtensions
  {
    public static HashSet<GameEntity> TargetStatusesOfType(this GameContext context, StatusTypeId statusTypeId, int targetId)
    {
      return ((EntityIndex<GameEntity, StatusKey>)context.GetEntityIndex(GameEntityIndices.StatusesOfType))
        .GetEntities(new StatusKey(targetId, statusTypeId));
    }

    public static HashSet<GameEntity> TargetStatChanges(this GameContext context, Stats stat, int targetId)
    {
      return ((EntityIndex<GameEntity, StatKey>)context.GetEntityIndex(GameEntityIndices.StatChanges))
        .GetEntities(new StatKey(targetId, stat));
    }
  }
}