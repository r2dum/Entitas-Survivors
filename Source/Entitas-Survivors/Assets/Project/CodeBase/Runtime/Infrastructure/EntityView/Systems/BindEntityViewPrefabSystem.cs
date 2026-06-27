using System.Collections.Generic;
using CodeBase.Runtime.Infrastructure.EntityView.Factory;
using Entitas;

namespace CodeBase.Runtime.Infrastructure.EntityView.Systems
{
  public class BindEntityViewPrefabSystem : IExecuteSystem
  {
    private readonly IEntityViewFactory _entityViewFactory;
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(32);

    public BindEntityViewPrefabSystem(GameContext gameContext, IEntityViewFactory entityViewFactory)
    {
      _entityViewFactory = entityViewFactory;
      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(GameMatcher.ViewPrefab)
        .NoneOf(GameMatcher.View));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
        _entityViewFactory.CreateViewForEntity(entity);
    }
  }
}