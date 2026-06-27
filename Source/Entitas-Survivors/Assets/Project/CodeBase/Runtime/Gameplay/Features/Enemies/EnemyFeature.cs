using CodeBase.Runtime.Gameplay.Features.Enemies.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.Enemies
{
  public sealed class EnemyFeature : Feature
  {
    public EnemyFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<InitializeSpawnTimerSystem>());

      Add(systemFactory.Create<EnemySpawnSystem>());

      Add(systemFactory.Create<EnemyChaseHeroSystem>());
      Add(systemFactory.Create<EnemyDeathSystem>());

      Add(systemFactory.Create<FinalizeEnemyDeathProcessingSystem>());
    }
  }
}