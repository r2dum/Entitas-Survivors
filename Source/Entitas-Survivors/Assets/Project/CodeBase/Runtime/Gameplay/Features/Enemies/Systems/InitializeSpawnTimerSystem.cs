using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Gameplay.Features.Enemies.Configs;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Systems
{
  public class InitializeSpawnTimerSystem : IInitializeSystem
  {
    private readonly IGameplayStaticDataService _staticDataService;

    public InitializeSpawnTimerSystem(IGameplayStaticDataService staticDataService) =>
      _staticDataService = staticDataService;

    public void Initialize()
    {
      WaveSetup firstWave = _staticDataService.GetWavesConfig().Waves[0];

      CreateEntity.Empty()
        .AddSpawnTimer(firstWave.UnlockTime);
    }
  }
}