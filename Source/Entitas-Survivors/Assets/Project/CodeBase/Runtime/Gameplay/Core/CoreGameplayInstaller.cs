using CodeBase.Runtime.Gameplay.Core.Collisions;
using CodeBase.Runtime.Gameplay.Core.Physics;
using CodeBase.Runtime.Gameplay.Core.Random;
using CodeBase.Runtime.Gameplay.Core.Time;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Core
{
  public class CoreGameplayInstaller : Installer<CoreGameplayInstaller>
  {
    public override void InstallBindings()
    {
      Container.Bind<IRandomService>().To<UnityRandomService>().AsSingle();
      Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
      Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
      Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
    }
  }
}