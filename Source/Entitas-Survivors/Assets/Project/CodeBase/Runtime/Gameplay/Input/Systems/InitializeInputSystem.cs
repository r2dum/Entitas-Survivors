using CodeBase.Runtime.Common.Entity;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Input.Systems
{
  public class InitializeInputSystem : IInitializeSystem
  {
    public void Initialize()
    {
      CreateEntity.Empty()
        .isInput = true;
    }
  }
}