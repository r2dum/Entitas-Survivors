using System.Collections.Generic;
using CodeBase.Runtime.Common.Times;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.LevelUp.Systems
{
  public class StartTimeOnLevelUpProcessedSystem : ReactiveSystem<GameEntity>
  {
    private readonly ITimeService _timeService;

    public StartTimeOnLevelUpProcessedSystem(GameContext gameContext, ITimeService timeService) : base(gameContext) =>
      _timeService = timeService;

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher.Processed.Added());

    protected override bool Filter(GameEntity entity) =>
      entity.isLevelUp && entity.isProcessed;

    protected override void Execute(List<GameEntity> entities)
    {
      foreach (GameEntity unused in entities)
        _timeService.StartTime();
    }
  }
}