using CodeBase.Runtime.Common.Destruct.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Common.Destruct
{
  public sealed class ProcessDestructedFeature : Feature
  {
    public ProcessDestructedFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<SelfDestructTimerSystem>());

      Add(systemFactory.Create<CleanupGameDestructedViewSystem>());
      Add(systemFactory.Create<CleanupGameDestructedSystem>());
    }
  }
}