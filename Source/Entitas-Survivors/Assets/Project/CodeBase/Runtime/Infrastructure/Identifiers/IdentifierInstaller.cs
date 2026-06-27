using Zenject;

namespace CodeBase.Runtime.Infrastructure.Identifiers
{
  public class IdentifierInstaller : Installer<IdentifierInstaller>
  {
    public override void InstallBindings() =>
      Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
  }
}