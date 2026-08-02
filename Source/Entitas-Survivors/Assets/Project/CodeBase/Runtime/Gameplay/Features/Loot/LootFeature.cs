using CodeBase.Runtime.Gameplay.Features.LevelUp.Systems;
using CodeBase.Runtime.Gameplay.Features.Loot.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.Loot
{
  public sealed class LootFeature : Feature
  {
    public LootFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<CastForPullablesSystem>());
      Add(systemFactory.Create<PullTowardsHeroSystem>());

      Add(systemFactory.Create<CollectWhenNearSystem>());
      Add(systemFactory.Create<CollectExperienceSystem>());
      Add(systemFactory.Create<CollectEffectItemSystem>());
      Add(systemFactory.Create<CollectStatusItemSystem>());

      Add(systemFactory.Create<UpdateExperienceMeterSystem>());

      Add(systemFactory.Create<CleanupCollectedSystem>());
    }
  }
}