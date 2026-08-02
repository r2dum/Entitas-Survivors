using System.Collections.Generic;
using CodeBase.Runtime.Common.Extensions;

namespace CodeBase.Runtime.Gameplay.Features.Armaments
{
  public static class ArmamentsExtensions
  {
    public static GameEntity AddTargetCollection(this GameEntity entity, int targetBufferSize)
    {
      return entity
        .AddTargetBuffer(new List<int>(targetBufferSize))
        .AddProcessedTargets(new List<int>(targetBufferSize))
        .With(x => x.isReadyToCollectTargets = true);
    }
  }
}