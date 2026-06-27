using System.Linq;
using CodeBase.Runtime.Common.EntityIndices;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Gameplay.Features.Statuses.Factory;

namespace CodeBase.Runtime.Gameplay.Features.Statuses.Applier
{
  public class StatusApplier : IStatusApplier
  {
    private readonly IStatusFactory _statusFactory;
    private readonly GameContext _gameContext;

    public StatusApplier(IStatusFactory statusFactory, GameContext gameContext)
    {
      _statusFactory = statusFactory;
      _gameContext = gameContext;
    }

    public GameEntity ApplyStatus(StatusSetup setup, int producerId, int targetId)
    {
      GameEntity status = _gameContext.TargetStatusesOfType(setup.StatusTypeId, targetId).FirstOrDefault();
      if (status != null)
        return status.ReplaceTimeLeft(setup.Duration);
      else
        return _statusFactory.CreateStatus(setup, producerId, targetId)
          .With(x => x.isApplied = true);
    }
  }
}