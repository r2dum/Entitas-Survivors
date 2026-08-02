using CodeBase.Runtime.Gameplay.Levels.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Levels
{
  public sealed class LevelFeature : Feature
  {
    public LevelFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<InitializeLevelTimeSystem>());
      Add(systemFactory.Create<TickLevelTimeSystem>());
    }
  }
}