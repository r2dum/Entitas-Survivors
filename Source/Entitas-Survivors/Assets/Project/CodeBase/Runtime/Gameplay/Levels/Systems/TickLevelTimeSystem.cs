using CodeBase.Runtime.Common.Times;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Levels.Systems
{
  public class TickLevelTimeSystem : IExecuteSystem
  {
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _entities;

    public TickLevelTimeSystem(GameContext gameContext, ITimeService timeService)
    {
      _timeService = timeService;
      _entities = gameContext.GetGroup(GameMatcher.LevelTime);
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
        entity.ReplaceLevelTime(entity.LevelTime + _timeService.DeltaTime);
    }
  }
}