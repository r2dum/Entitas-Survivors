using System.Collections.Generic;
using CodeBase.Runtime.Infrastructure.AssetManagement;
using Entitas;

namespace CodeBase.Runtime.Infrastructure.EntityView.Systems
{
  public class LoadEntityViewFromAddressSystem : IExecuteSystem
  {
    private readonly IEntityViewAssetLoader _entityViewAssetLoader;

    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(32);

    public LoadEntityViewFromAddressSystem(GameContext gameContext, IEntityViewAssetLoader entityViewAssetLoader)
    {
      _entityViewAssetLoader = entityViewAssetLoader;

      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(GameMatcher.ViewAddress)
        .NoneOf(
          GameMatcher.View,
          GameMatcher.ViewPrefab,
          GameMatcher.ViewAddressLoading));
    }
    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        entity.isViewAddressLoading = true;
        _entityViewAssetLoader.Load(entity, entity.ViewAddress);
      }
    }
  }
}