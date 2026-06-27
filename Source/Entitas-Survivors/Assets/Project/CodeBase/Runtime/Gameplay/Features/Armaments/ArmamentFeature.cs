using CodeBase.Runtime.Gameplay.Features.Armaments.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.Armaments
{
  public sealed class ArmamentFeature : Feature
  {
    public ArmamentFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<MarkProcessedOnTargetLimitExceededSystem>());

      Add(systemFactory.Create<FollowProducerSystem>());

      Add(systemFactory.Create<FinalizeProcessedArmamentsSystem>());
    }
  }
}