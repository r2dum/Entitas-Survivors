using CodeBase.Runtime.Gameplay.Input.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Input
{
  public sealed class InputFeature : Feature
  {
    public InputFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<InitializeInputSystem>());
      Add(systemFactory.Create<EmitInputSystem>());
    }
  }
}