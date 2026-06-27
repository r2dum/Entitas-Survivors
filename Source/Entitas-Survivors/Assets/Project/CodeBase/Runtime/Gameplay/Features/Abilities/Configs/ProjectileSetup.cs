using System;

namespace CodeBase.Runtime.Gameplay.Features.Abilities.Configs
{
  [Serializable]
  public class ProjectileSetup
  {
    public float Speed;
    public int Pierce = 1;
    public int ProjectileCount = 1;
    public float ContactRadius;
    public float OrbitRadius;
    public float Lifetime;
  }
}