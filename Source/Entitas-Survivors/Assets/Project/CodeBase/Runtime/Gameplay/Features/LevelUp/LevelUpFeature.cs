using CodeBase.Runtime.Gameplay.Features.LevelUp.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.LevelUp
{
  public sealed class LevelUpFeature : Feature
  {
    public LevelUpFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<OpenLevelUpWindowSystem>());
      Add(systemFactory.Create<StopTimeOnLevelUpSystem>());

      Add(systemFactory.Create<UpgradeAbilityOnRequestSystem>());

      Add(systemFactory.Create<StartTimeOnLevelUpProcessedSystem>());

      Add(systemFactory.Create<FinalizeProcessedLevelUpsSystem>());
    }
  }
}