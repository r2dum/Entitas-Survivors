using CodeBase.Runtime.Gameplay.Cameras.Systems;
using CodeBase.Runtime.Gameplay.Features.Hero.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.Hero
{
  public sealed class HeroFeature : Feature
  {
    public HeroFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<InitializeHeroSystem>());

      Add(systemFactory.Create<SetHeroDirectionByInputSystem>());
      Add(systemFactory.Create<CameraFollowHeroSystem>());
      Add(systemFactory.Create<AnimateHeroMovementSystem>());
      Add(systemFactory.Create<HeroDeathSystem>());

      Add(systemFactory.Create<FinalizeHeroDeathProcessingSystem>());
    }
  }
}