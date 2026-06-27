using CodeBase.Runtime.Infrastructure.Debug.Log;
using Zenject;

namespace CodeBase.Runtime.Infrastructure.Debug
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