using CodeBase.Runtime.Common.Entity;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Levels.Systems
{
  public class InitializeLevelTimeSystem : IInitializeSystem
  {
    public void Initialize()
    {
      CreateEntity.Empty()
        .AddLevelTime(0f);
    }
  }
}