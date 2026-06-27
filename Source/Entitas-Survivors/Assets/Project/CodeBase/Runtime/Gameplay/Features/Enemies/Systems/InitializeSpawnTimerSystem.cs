using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Gameplay.Core;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Systems
{
  public class InitializeSpawnTimerSystem : IInitializeSystem
  {
    public void Initialize()
    {
      CreateEntity.Empty()
        .AddSpawnTimer(GameplayConstants.EnemySpawnTimer);
    }
  }
}