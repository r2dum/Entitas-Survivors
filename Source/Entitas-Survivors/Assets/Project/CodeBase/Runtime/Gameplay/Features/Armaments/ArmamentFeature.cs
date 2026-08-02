using CodeBase.Runtime.Gameplay.Features.Armaments.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.Armaments
{
  public sealed class ArmamentFeature : Feature
  {
    public ArmamentFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<MarkProcessedOnTargetPierceLimitExceededSystem>());
      Add(systemFactory.Create<MarkProcessedOnTargetBounceLimitExceededSystem>());
      Add(systemFactory.Create<MarkProcessedOnDestinationReachedSystem>());

      Add(systemFactory.Create<RedirectBouncingArmamentToNextTargetSystem>());
      Add(systemFactory.Create<SpawnShardsOnScatteringFireBallReachedSystem>());
      Add(systemFactory.Create<SpawnFireOnDragonFruitDestinationReachedSystem>());

      Add(systemFactory.Create<FollowProducerSystem>());

      Add(systemFactory.Create<FinalizeProcessedArmamentsSystem>());
    }
  }
}