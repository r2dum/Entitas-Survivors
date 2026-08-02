using Zenject;

namespace CodeBase.Runtime.Services.StaticData
{
  public class StaticDataInstaller : Installer<StaticDataInstaller>
  {
    public override void InstallBindings() =>
      Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
  }
}