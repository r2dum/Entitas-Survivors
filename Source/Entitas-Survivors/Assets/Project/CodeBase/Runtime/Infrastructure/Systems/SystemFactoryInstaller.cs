using Zenject;

namespace CodeBase.Runtime.Infrastructure.Systems
{
  public class SystemFactoryInstaller : Installer<SystemFactoryInstaller>
  {
    public override void InstallBindings() =>
      Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
  }
}