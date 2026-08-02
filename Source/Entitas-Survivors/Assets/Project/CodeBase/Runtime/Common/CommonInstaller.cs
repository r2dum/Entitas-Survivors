using CodeBase.Runtime.Common.Randoms;
using CodeBase.Runtime.Common.Times;
using Zenject;

namespace CodeBase.Runtime.Common
{
  public class CommonInstaller : Installer<CommonInstaller>
  {
    public override void InstallBindings()
    {
      Container.Bind<IRandomService>().To<UnityRandomService>().AsSingle();
      Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
    }
  }
}