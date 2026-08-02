using System.Collections.Generic;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Common.Times;
using CodeBase.Runtime.Gameplay.Cameras.Provider;
using CodeBase.Runtime.Gameplay.Features.Enemies.Configs;
using CodeBase.Runtime.Gameplay.Features.Enemies.Factory;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
using Entitas;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Systems
{
  public class EnemySpawnSystem : IExecuteSystem
  {
    private const float SpawnDistanceGap = 0.5f;

    private readonly ITimeService _timeService;
    private readonly IEnemyFactory _enemyFactory;
    private readonly ICameraProvider _cameraProvider;
    private readonly IGameplayStaticDataService _staticDataService;

    private readonly IGroup<GameEntity> _spawnTimers;
    private readonly IGroup<GameEntity> _levelTimes;
    private readonly IGroup<GameEntity> _heroes;

    public EnemySpawnSystem(GameContext gameContext, ITimeService timeService, IEnemyFactory enemyFactory,
      ICameraProvider cameraProvider, IGameplayStaticDataService staticDataService)
    {
      _timeService = timeService;
      _enemyFactory = enemyFactory;
      _cameraProvider = cameraProvider;
      _staticDataService = staticDataService;

      _spawnTimers = gameContext.GetGroup(GameMatcher.SpawnTimer);
      _levelTimes = gameContext.GetGroup(GameMatcher.LevelTime);
      _heroes = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      float levelTime = GetLevelTime();
      WaveSetup wave = GetWaveByLevelTime(levelTime);

      foreach (GameEntity timer in _spawnTimers)
      {
        timer.ReplaceSpawnTimer(timer.SpawnTimer - _timeService.DeltaTime);

        if (timer.SpawnTimer > 0)
          continue;

        timer.ReplaceSpawnTimer(wave.SpawnInterval);

        List<EnemyConfig> unlockedEnemies = GetUnlockedEnemyConfigs(levelTime);

        foreach (GameEntity hero in _heroes)
        {
          for (int i = 0; i < wave.EnemiesPerSpawn; i++)
          {
            EnemyTypeId selectedEnemyType = SelectEnemyTypeBySpawnWeight(unlockedEnemies);
            _enemyFactory.CreateEnemy(selectedEnemyType, at: RandomSpawnPosition(hero.WorldPosition));
          }
        }
      }
    }

    private float GetLevelTime()
    {
      float levelTime = 0f;

      foreach (GameEntity entity in _levelTimes)
        levelTime = entity.LevelTime;

      return levelTime;
    }

    private WaveSetup GetWaveByLevelTime(float levelTime)
    {
      List<WaveSetup> waves = _staticDataService.GetWavesConfig().Waves;
      WaveSetup currentWave = waves[0];

      foreach (WaveSetup wave in waves)
        if (levelTime >= wave.UnlockTime)
          currentWave = wave;

      return currentWave;
    }

    private List<EnemyConfig> GetUnlockedEnemyConfigs(float levelTime)
    {
      List<EnemyConfig> unlocked = new();
      List<EnemyConfig> enemyConfigs = _staticDataService.GetEnemyConfigs();

      foreach (EnemyConfig enemyConfig in enemyConfigs)
        if (levelTime >= enemyConfig.UnlockTime)
          unlocked.Add(enemyConfig);

      return unlocked;
    }

    private EnemyTypeId SelectEnemyTypeBySpawnWeight(List<EnemyConfig> availableConfigs)
    {
      float totalWeight = 0f;

      foreach (EnemyConfig enemyConfig in availableConfigs)
        totalWeight += enemyConfig.SpawnWeight;

      if (totalWeight == 0f)
        return EnemyTypeId.GoblinWarrior;

      float randomWeightPoint = Random.Range(0f, totalWeight);
      float accumulatedWeight = 0f;

      foreach (EnemyConfig enemyConfig in availableConfigs)
      {
        accumulatedWeight += enemyConfig.SpawnWeight;
        if (randomWeightPoint < accumulatedWeight)
          return enemyConfig.TypeId;
      }

      return EnemyTypeId.GoblinWarrior;
    }

    private Vector2 RandomSpawnPosition(Vector2 heroWorldPosition)
    {
      bool startWithHorizontal = Random.Range(0, 2) == 0;

      return startWithHorizontal
        ? HorizontalSpawnPosition(heroWorldPosition)
        : VerticalSpawnPosition(heroWorldPosition);
    }

    private Vector2 HorizontalSpawnPosition(Vector2 heroWorldPosition)
    {
      Vector2[] horizontalDirections =
      {
        Vector2.left, Vector2.right
      };
      Vector2 primaryDirection = horizontalDirections.PickRandom();

      float horizontalOffsetDistance = _cameraProvider.WorldScreenWidth / 2 + SpawnDistanceGap;
      float verticalRandomOffset = Random.Range(-_cameraProvider.WorldScreenHeight / 2, _cameraProvider.WorldScreenHeight / 2);

      return heroWorldPosition + primaryDirection * horizontalOffsetDistance + Vector2.up * verticalRandomOffset;
    }

    private Vector2 VerticalSpawnPosition(Vector2 heroWorldPosition)
    {
      Vector2[] verticalDirections =
      {
        Vector2.up, Vector2.down
      };
      Vector2 primaryDirection = verticalDirections.PickRandom();

      float verticalOffsetDistance = _cameraProvider.WorldScreenHeight / 2 + SpawnDistanceGap;
      float horizontalRandomOffset = Random.Range(-_cameraProvider.WorldScreenWidth / 2, _cameraProvider.WorldScreenWidth / 2);

      return heroWorldPosition + primaryDirection * verticalOffsetDistance + Vector2.right * horizontalRandomOffset;
    }
  }
}