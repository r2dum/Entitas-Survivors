using CodeBase.Runtime.Gameplay.Features.TargetCollection.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.TargetCollection
{
  public sealed class CollectTargetsFeature : Feature
  {
    public CollectTargetsFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<CollectTargetsIntervalSystem>());

      Add(systemFactory.Create<CastForTargetsNoPierceLimitSystem>());
      Add(systemFactory.Create<CastForTargetsWithPierceLimitSystem>());
      Add(systemFactory.Create<CastForTargetsWithBounceLimitSystem>());

      Add(systemFactory.Create<MarkReachedSystem>());

      Add(systemFactory.Create<CleanupTargetBuffersSystem>());
      Add(systemFactory.Create<CleanupReachedSystem>());
    }
  }
}