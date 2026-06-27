using Zenject;

namespace CodeBase.Runtime.Infrastructure.SceneLoading
{
  public class SceneLoaderInstaller : Installer<SceneLoaderInstaller>
  {
    public override void InstallBindings() =>
      Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
  }
}