using CodeBase.Runtime.Gameplay.Features.TargetCollection.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.TargetCollection
{
  public sealed class CollectTargetsFeature : Feature
  {
    public CollectTargetsFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<CollectTargetsIntervalSystem>());

      Add(systemFactory.Create<CastForTargetsNoLimitSystem>());
      Add(systemFactory.Create<CastForTargetsWithLimitSystem>());
      Add(systemFactory.Create<MarkReachedSystem>());

      Add(systemFactory.Create<CleanupTargetBuffersSystem>());
    }
  }
}