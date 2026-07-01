using CodeBase.Runtime.Infrastructure.Debugs.Log;
using Zenject;

namespace CodeBase.Runtime.Infrastructure.Debugs
{
  public class DebugInstaller : Installer<DebugInstaller>
  {
    public override void InstallBindings()
    {
      Container
        .BindInterfacesAndSelfTo<LogService>()
        .AsSingle();
    }
  }
}