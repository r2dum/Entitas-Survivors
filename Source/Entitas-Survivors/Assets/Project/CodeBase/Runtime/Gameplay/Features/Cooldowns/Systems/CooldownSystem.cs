using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Core.Time;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Cooldowns.Systems
{
  public class CooldownSystem : IExecuteSystem
  {
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _cooldownables;
    private readonly List<GameEntity> _buffer = new(32);

    public CooldownSystem(GameContext gameContext, ITimeService timeService)
    {
      _timeService = timeService;
      _cooldownables = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Cooldown,
          GameMatcher.CooldownLeft));
    }

    public void Execute()
    {
      foreach (GameEntity cooldownable in _cooldownables.GetEntities(_buffer))
      {
        cooldownable.ReplaceCooldownLeft(cooldownable.CooldownLeft - _timeService.DeltaTime);

        if (cooldownable.CooldownLeft <= 0)
        {
          cooldownable.isCooldownUp = true;
          cooldownable.RemoveCooldownLeft();
        }
      }
    }
  }
}