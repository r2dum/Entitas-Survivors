using CodeBase.Runtime.Gameplay.Core.Collisions;
using CodeBase.Runtime.Gameplay.Core.Physics;
using CodeBase.Runtime.Gameplay.Core.Visuals.Appearance;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Core
{
  public class CoreGameplayInstaller : Installer<CoreGameplayInstaller>
  {
    public override void InstallBindings()
    {
      Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
      Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
      Container.Bind<IAppearanceSkinFactory>().To<AppearanceSkinFactory>().AsSingle();
    }
  }
}