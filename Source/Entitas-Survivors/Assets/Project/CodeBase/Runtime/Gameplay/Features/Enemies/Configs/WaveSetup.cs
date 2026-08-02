using System;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Configs
{
  [Serializable]
  public class WaveSetup
  {
    public float UnlockTime;
    public float SpawnInterval;
    public int EnemiesPerSpawn = 1;
  }
}