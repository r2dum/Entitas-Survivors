using System.Collections.Generic;
using CodeBase.Runtime.Common.Times;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.LevelUp.Systems
{
  public class StopTimeOnLevelUpSystem : ReactiveSystem<GameEntity>
  {
    private readonly ITimeService _timeService;

    public StopTimeOnLevelUpSystem(GameContext gameContext, ITimeService timeService) : base(gameContext) =>
      _timeService = timeService;

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher.LevelUp.Added());

    protected override bool Filter(GameEntity entity) => true;

    protected override void Execute(List<GameEntity> entities)
    {
      foreach (GameEntity unused in entities)
        _timeService.StopTime();
    }
  }
}