using System.Collections.Generic;
using CodeBase.Runtime.UI.Windows;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.LevelUp.Systems
{
  public class OpenLevelUpWindowSystem : ReactiveSystem<GameEntity>
  {
    private readonly IWindowService _windowService;

    public OpenLevelUpWindowSystem(GameContext gameContext, IWindowService windowService) : base(gameContext) =>
      _windowService = windowService;

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher.LevelUp.Added());

    protected override bool Filter(GameEntity entity) => true;

    protected override void Execute(List<GameEntity> entities)
    {
      foreach (GameEntity unused in entities)
        _windowService.Open(WindowTypeId.LevelUpWindow);
    }
  }
}