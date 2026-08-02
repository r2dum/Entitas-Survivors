using CodeBase.Runtime.Progress.Provider;
using CodeBase.Runtime.Progress.SaveLoad;
using Zenject;

namespace CodeBase.Runtime.Progress
{
  public class ProgressInstaller : Installer<ProgressInstaller>
  {
    public override void InstallBindings()
    {
      Container.Bind<IProgressProvider>().To<ProgressProvider>().AsSingle();
      Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
    }
  }
}