using CodeBase.Runtime.UI.Windows.Factory;
using Zenject;

namespace CodeBase.Runtime.UI.Windows
{
  public class WindowsInstaller : Installer<WindowsInstaller>
  {
    public override void InstallBindings()
    {
      Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();
      Container.Bind<IWindowService>().To<WindowService>().AsSingle();
    }
  }
}