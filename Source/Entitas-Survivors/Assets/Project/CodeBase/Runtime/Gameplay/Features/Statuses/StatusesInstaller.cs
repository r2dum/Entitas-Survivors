using CodeBase.Runtime.Gameplay.Features.Statuses.Applier;
using CodeBase.Runtime.Gameplay.Features.Statuses.Factory;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Features.Statuses
{
  public class StatusesInstaller : Installer<StatusesInstaller>
  {
    public override void InstallBindings()
    {
      Container.Bind<IStatusApplier>().To<StatusApplier>().AsSingle();
      Container.Bind<IStatusFactory>().To<StatusFactory>().AsSingle();
    }
  }
}